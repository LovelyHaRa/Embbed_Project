//DSS 객체 생성
let dss_info = {
	querytext: '',
	mesg: '',
	uword: '',
	sysAct: '',
	sPattern: ''
};
// 모듈 import
setQuery=require('./requireMessage');

module.exports = {
    analysisMessage: function (msg) {
        // 질의어 추출
        dss_info.uword=msg.uword;
        // 답변 추출
        mesg=msg.action[0].mesg;
        mesg = mesg.replace('<![CDATA[', '');
        mesg = mesg.replace(']]>', '');
        mesg = mesg.replace(/\\/g,'');        
        dss_info.mesg=mesg;
        // 기타 속성 추출
        dss_info.sysAct=msg.sysAct;
        dss_info.sPattern=msg.sPattern;
        //질의어 출력 및 반환
        console.log("질의어 : " + dss_info.uword);
        return dss_info.uword;
    },

    requireDrink: function(msg) {
        // 질의어를 집합으로 구성
        var setA =new Set();
        var str=msg.split(' ');
        for (var i=0; i<str.length; i++) {
            setA.add(str[i]);
        }
        // 집합 배열화
        arrA=[...setA];        
        arrB=[...setQuery.setDrink];
        // 질의어와 대화모델 집합 교집합 연산
        var resSet=getIntersectSet(arrA,arrB);
        // 배열을 집합으로 변경            
        resSet=new Set(resSet);
        // 교집합 결과 배열화
        var arrC=[...resSet];
        // 질의어와 교집합 결과 집합 차집합 연산
        var cupSet=getDiffSet(arrA,arrC);
        // 지정되지 않은 형용사, 컵종류 단어 여부 검사
        var anotherCup=0;
        for(var i=0;i<cupSet.length;i++) {
            if(cupSet[i].length>1) {
                anotherCup=1;
                break;
            }
        }
        // 음료, 컵종류 판단변수
        var cup=0;
        var drink=0;
        // 음료, 컵종류 결정
        if((resSet.has('뽑아줘') || resSet.has('줄래'))) {                
            if(resSet.has('머그컵')) {
                cup=3;
            } else if(resSet.has('종이컵')) {
                cup=2;
                console.log('확인');
            }
            if(resSet.has('콜라')) {
                if(anotherCup==0 && cup==0) {                    
                    cup=1;
                }
                drink=1;
            }
            else if(resSet.has('사이다')) {
                if(anotherCup==0 && cup==0) {
                    cup=1;
                }
                drink=2;
            }
            else if(resSet.has('포카리')) {
                if(anotherCup==0 && cup==0) {
                    cup=1;
                }
                drink=3;
            }
            else if(resSet.has('탄산수')) {
                if(anotherCup==0 && cup==0) {
                    cup=1;
                }
                drink=4;
            }
            else if(resSet.has('아무') && resSet.has('거나')) {
                if(anotherCup==0 && cup==0) {
                    cup=1;
                }
                var radNum=Math.floor(Math.random() * setQuery.drink)+1;
                drink=radNum;
            }
        }
        // 음료수와 컵이 모두 결정되었을 때 반환
        if(drink > 0 && cup > 0) {
            return {
                drinkNum:drink,
                cupNum:cup
            }
        }        
    }
};

// 차집합 연산 함수
function getDiffSet(a, b) {
    var tmp={}, res=[];
    for(var i=0;i<a.length;i++) tmp[a[i]]=1;
    for(var i=0;i<b.length;i++) { if(tmp[b[i]]) delete tmp[b[i]]; }
    for(var k in tmp) res.push(k);
    return res;
}

// 교집합 연산 함수
function getIntersectSet(a, b) {
    var tmp={}, res=[];
    for(var i=0;i<a.length;i++) tmp[a[i]]=1;
    for(var i=0;i<b.length;i++) if(tmp[b[i]]) res.push(b[i]);
    return res;
}