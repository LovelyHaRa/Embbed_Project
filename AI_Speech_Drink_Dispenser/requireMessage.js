// 질의 요구조건 집합 결정
var setQuery = {
    setDrink: new Set(),
    drink:4,
    cup:3
};
setQuery.setDrink.add('뽑아줘');
setQuery.setDrink.add('줄래');
setQuery.setDrink.add('종이컵');
setQuery.setDrink.add('머그컵');
setQuery.setDrink.add('콜라');
setQuery.setDrink.add('사이다');
setQuery.setDrink.add('포카리');
setQuery.setDrink.add('탄산수');
setQuery.setDrink.add('아무');
setQuery.setDrink.add('거나');

module.exports=setQuery;