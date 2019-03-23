// 모듈 import
var wpi =require('wiringpi-node');
var sleep=require('sleep');
wpi.setup('gpio');

// LED PIN 세팅
var onoffLED=13;
var LED1=23;
var LED2=25;
var LED3=17;
var LED4=22;

// 펌프모터 PIN 세팅
var LM1=23;
var LM2=24;
var RM1=25;
var RM2=12;
var LM3=17;
var LM4=27;
var RM3=22;
var RM4=5;

// PINMODE 세팅
wpi.pinMode(onoffLED, wpi.OUTPUT);
wpi.pinMode(LED1, wpi.OUTPUT);
wpi.pinMode(LED2, wpi.OUTPUT);
wpi.pinMode(LED3, wpi.OUTPUT);
wpi.pinMode(LED4, wpi.OUTPUT);
wpi.pinMode(LM1, wpi.OUTPUT);
wpi.pinMode(LM2, wpi.OUTPUT);
wpi.pinMode(RM1, wpi.OUTPUT);
wpi.pinMode(RM2, wpi.OUTPUT);
wpi.pinMode(LM3, wpi.OUTPUT);
wpi.pinMode(LM4, wpi.OUTPUT);
wpi.pinMode(RM3, wpi.OUTPUT);
wpi.pinMode(RM4, wpi.OUTPUT);

module.exports = {
    // 모터 작동 함수
    operateMotor: function (num,cupNum) {
        var time=4500;
        // 컵 종류별 추출시간(ms)
        switch (cupNum) {
            case 1 : time=4500; break;
            case 2 : time=9120; break;
            case 3 : time=11000; break;
            default : time=4500; break;
        }

        if(num==1) {
            console.log('상태 : 콜라 제공 중');
            wpi.digitalWrite(LM1, wpi.HIGH);
            wpi.digitalWrite(LM2, wpi.LOW);
            sleep.msleep(time);
            wpi.digitalWrite(LM1, wpi.LOW);
            wpi.digitalWrite(LM2, wpi.LOW);
        } else {
            wpi.digitalWrite(LM1, wpi.LOW);
            wpi.digitalWrite(LM2, wpi.LOW);
        }
        if(num==2) {
            console.log('상태 : 사이다 제공 중');
            wpi.digitalWrite(RM1, wpi.HIGH);
            wpi.digitalWrite(RM2, wpi.LOW);
            sleep.msleep(time);
            wpi.digitalWrite(RM1, wpi.LOW);
            wpi.digitalWrite(RM2, wpi.LOW);
        } else {
            wpi.digitalWrite(RM1, wpi.LOW);
            wpi.digitalWrite(RM2, wpi.LOW);
        }
        if(num==3) {
            console.log('상태 : 포카리 제공 중');
            wpi.digitalWrite(LM3, wpi.HIGH);
            wpi.digitalWrite(LM4, wpi.LOW);
            time+=1000;
            sleep.msleep(time);
            wpi.digitalWrite(LM3, wpi.LOW);
            wpi.digitalWrite(LM4, wpi.LOW);
        } else {
            wpi.digitalWrite(LM3, wpi.LOW);
            wpi.digitalWrite(LM4, wpi.LOW);
        }
        if(num==4) {
            console.log('상태 : 탄산수 제공 중');
            wpi.digitalWrite(RM3, wpi.HIGH);
            wpi.digitalWrite(RM4, wpi.LOW);
            time+=1000;
            sleep.msleep(time);
            wpi.digitalWrite(RM3, wpi.LOW);
            wpi.digitalWrite(RM4, wpi.LOW);
        } else {
            wpi.digitalWrite(RM3, wpi.LOW);
            wpi.digitalWrite(RM4, wpi.LOW);
        }
    },
    // ON/OFF LED 작동 함수
    onoffLED: function(state) {
        if(state) {
            wpi.digitalWrite(onoffLED,wpi.HIGH);
        } else {
            wpi.digitalWrite(onoffLED,wpi.LOW);
        }            
    }
};