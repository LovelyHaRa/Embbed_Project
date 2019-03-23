const record=require('node-record-lpcm16');
const aikit=require('./aimakerskitutil');
const Speaker=require('speaker');
const fs=require('fs');

//for playing pcm sound
const soundBuffer=fs.readFileSync('../data/sample_sound.wav');
const pcmplay=new Speaker({
	channels:1,
	bitDepth:16,
	sampleRate:16000
});
//node version check
const nodeVersion=process.version.split('.')[0];
let ktkws=null;
if(nodeVersion==='v6') ktkws=require('./ktkws');
else if(nodeVersion==='v8') ktkws=require('./ktkws_v8');

// 모듈 import
const speech=require('./speech');
const hadware=require('./hardware');
const resMsg=require('./result');

// KT ai-makers-kit API 정보 초기화.
const client_id='';
const client_key='';
const client_secret='';
const json_path='/home/pi/key/clientKey.json';
const cert_path='../data/ca-bundle.pem';
const proto_path='../data/gigagenieRPC.proto';

// 호출어 결정 및 마이크 초기화
const kwstext=['기가지니','지니야'];
const kwsflag=1; // 0 : 기가지니 1 : 지니야
let pcm=null;
function initMic(){
        return record.start({
                sampleRateHertz: 16000,
                threshold: 0,
                verbose: false,
                recordProgram: 'arecord',
        })
};
ktkws.initialize('../data/kwsmodel.pack');
ktkws.startKws(kwsflag);
let mic=initMic();

// API 초기화
//aikit.initialize(client_id,client_key,client_secret,cert_path,proto_path);
aikit.initializeJson(json_path,cert_path,proto_path);

// 호출어 인식
let mode=0;//0:kws, 1:queryByVoice
let ktstt=null;
mic.on('data',(data)=>{
	if(mode===0){ //1)
		result=ktkws.pushBuffer(data);
		if(result===1) { //2)
			console.log("상태 : 디스펜서 호출됨");
			pcmplay.write(soundBuffer);
			setTimeout(startQueryVoice,1000); // 3)
		}
	} else {
    		ktstt.write({audioContent:data}); //4)
	}
});

// ON/OFF LED 켜짐
hadware.onoffLED(1);
// 터미널 UI info 출력
console.log('--------------------------------');
console.log('|                              |');
console.log('|                              |');
console.log('|     Embedded System B2       |');
console.log('|    음성인식 음료 디스펜서    |');
console.log('|                              |');
console.log('|                              |');
console.log('--------------------------------');
console.log('\''+kwstext[kwsflag]+'\'로 디스펜서를 호출하십시오');
console.log('\'Ctrl+C\'로 종료할 수 있습니다.');

// 음성메시지 인식 및 처리
function startQueryVoice(){
	ktstt=aikit.queryByVoice((err,msg)=>{
		if(err){
			console.log('Error 발생');
			mode=0;
		} else {
            // 음성메시지 정상 인식
            console.log('--------------------------------');
			console.log('상태 : 정상적으로 음성인식 하였습니다.');
			const action=msg.action[0];
			if(action){
                // 음성메시지 추출
                var res_msg=speech.analysisMessage(msg);
                // 음성메시지 분석
                var res = {};
                res=speech.requireDrink(res_msg);
                // 결과 메시지 생성(랜덤)
                var msg='';                
				if(res==undefined) {
					msg=resMsg.responseErr(); // 질의어가 요구조건에 맞지 않을 때
				} else {
                    //질의어가 요구조건에 맞을 때
					msg=resMsg.responseMsg(res.drinkNum,res.cupNum);					
                }
                // 결과 메시지 TTS 비동기 호출
				let kttts=aikit.getText2VoiceStream({text:msg,lang:0,mode:0});
				kttts.on('error',(error)=>{
					console.log('TTS Error:'+error);
				});
				kttts.on('data',(data)=>{	
                    if(data.streamingResponse==='resOptions' && data.resOptions.resultCd===200) {
                        console.log('--------------------------------');
                    }
					if(data.streamingResponse==='audioContent') {
						pcmplay.write(data.audioContent);
					} else {
						console.log('상태 : 답변이 정상적으로 출력되었습니다');
						console.log('답변 메시지 : ' + msg);
					}
				});
				kttts.on('end',()=>{
                    console.log('상태 : TTS 종료');
                    console.log('--------------------------------');
                    console.log('\''+kwstext[kwsflag]+'\'로 디스펜서를 호출하십시오');
                    console.log('\'Ctrl+C\'로 종료할 수 있습니다.');
					mode=0;
                });
                // 하드웨어 작동
				if(res!=undefined) {
					hadware.operateMotor(res.drinkNum,res.cupNum);
				}
				mode=0
			} else {
                console.log('--------------------------------');
                console.log('\''+kwstext[kwsflag]+'\'로 디스펜서를 호출하십시오');
                console.log('\'Ctrl+C\'로 종료할 수 있습니다.');
                mode=0;
            }
        }        
	});
	ktstt.write({reqOptions:{lang:0,userSession:'12345',deviceId:'D06190914TP808IQKtzq'}});
    mode=1;
};

process.on('SIGINT', function() {
    console.log('');
	console.log("Bye Bye");
	hadware.onoffLED(0);
	process.exit();
});