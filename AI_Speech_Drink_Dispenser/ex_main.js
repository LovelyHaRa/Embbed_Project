/* 스피커 모듈 */
const Speaker=require('speaker');
const pcmplay=new Speaker({
	channels:1,
	bitDepth:16,
	sampleRate:16000
});

/* KT ai-makers-kit 사용자 정보 설정 */
const aikit=require('./aimakerskitutil');
const client_id='';
const client_key='';
const client_secret='';
const json_path='/home/pi/key/clientKey.json';
const cert_path='../data/ca-bundle.pem';
const proto_path='../data/gigagenieRPC.proto';

const speech=require('./speech');
const hadware=require('./hardware');
const result=require('./result');

//aikit.initialize(client_id,client_key,client_secret,cert_path,proto_path);
aikit.initializeJson(json_path,cert_path,proto_path);
var queryInfo = {
	queryText:'아무 거나 종이컵 에 뽑아줘',
	userSession:'12345',
	deviceId:'D06190914TP808IQKtzq'};

aikit.queryByText(queryInfo,(err,msg)=>{
	if(err){
		console.log(JSON.stringify(err));
	} else {
		console.log('Msg:'+JSON.stringify(msg));
        var res_msg=speech.analysisMessage(msg);
        var res = {};
        res=speech.requireDrink(res_msg);
        if(res==undefined) {
            var errMsg=result.responseErr();
            console.log(errMsg);
        } else {
            var resMsg=result.responseMsg(res.drinkNum,res.cupNum);
            console.log(resMsg);
            hadware.operateMotor(res.drinkNum,res.cupNum);
        }
	}
})