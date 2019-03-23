// 모듈 import
response=require('./resultMessage');

module.exports = {
    // 정상 결과 메시지 결정 함수
    responseMsg: function (drinkNum, cupNum) {
        var resStr = '';
        // 음료 결정
        resStr+=response.strDrink[drinkNum-1];
        // 랜덤으로 메시지 결정
        var resNum=Math.floor(Math.random() * response.countCup);
        resNum+=(cupNum-1)*3;
        resStr+=response.strMsg[resNum];
        return resStr;
    },
    // 에러 메시지 결정 함수
    responseErr: function () {
        // 랜덤으로 대화 메시지 결정
        var resNum=Math.floor(Math.random() * response.countErr);
        var resStr='';
        resStr+=response.strErr[resNum];
        return resStr;
    }
};