// 결과 메시지 객체
var response = {
    strDrink:new Array(),
    strMsg:new Array(),
    strErr:new Array(),
    countCup:3,
    countErr:0
};
// 음료수 종류
response.strDrink[0]='콜라';
response.strDrink[1]='사이다';
response.strDrink[2]='포카리';
response.strDrink[3]='탄산수';

// 결과 메시지 종류
response.strMsg[0]='를 지금 제공했습니다.'
response.strMsg[1]='가 지금 나왔습니다.'
response.strMsg[2]=' 나왔습니다아아아아아'
response.strMsg[3]='를 종이컵에 꽉 채워 제공했습니다.'
response.strMsg[4]='가 지금 종이컵 양 만큼 나왔습니다.'
response.strMsg[5]='가 종이컵 양 만큼 나왔습니다아아아아아'
response.strMsg[6]='를 머그컵에 꽉 채워 제공했습니다.'
response.strMsg[7]='가 지금 머그컵 양 만큼 나왔습니다.'
response.strMsg[8]='가 머그컵 양 만큼 나왔습니다아아아아아'

// 에러 메시지 종류
response.strErr[0]='무슨 말씀인지 못알아들었어요';
response.strErr[1]='어떤 음료수를 말씀하시는지 모르겠어요';
response.strErr[2]='알아들을수가 없네요';

response.countErr=response.strErr.length;

module.exports=response;