#include <Servo.h>
Servo myservo1; //모터1(수도꼭지)
Servo myservo2; //모터2(배출구)
unsigned char Re_buf[11], counter = 0;
unsigned char sign = 0;
float T0 = 0, TA = 0;

int switch1Pin = 2; //로커스위치에 대한 변수(ON)
int switch2Pin = 4; //로커스위치에 대한 변수(OFF)
int ledPin = 13; //적색 LED(스위치 ON/OFF 표시)
int ledOn = 12; //녹색 LED(수도꼭지 ON/OFF 표시)
int ledVel = 0;

void setup() {
	Serial.begin(115200);
	delay(1);
	Serial.write(0xA5);
	Serial.write(0x45);
	Serial.write(0xEA);
	myservo1.attach(8);
	myservo2.attach(7);

	pinMode(A0, INPUT); //수위센서2
	pinMode(48, INPUT); //수위센서1
	pinMode(switch1Pin, INPUT);
	pinMode(switch2Pin, INPUT);
	pinMode(ledPin, OUTPUT);
	pinMode(ledOn, OUTPUT);

}

void loop() {
	unsigned char i = 0, sum = 0;
	int level2 = analogRead(A0);
	int level1 = digitalRead(48);

	if (sign) {
		sign = 0;
		for (i = 0; i < 8; i++)
			sum += Re_buf[i];

		if (sum == Re_buf[i]) {
			T0 = (float)(Re_buf[4] << 8 | Re_buf[5] / 100);

			Serial.print("temp:");//시리얼 모니터에 온도값 출력
			Serial.println(T0);
			Serial.print("level1:");//시리얼 모니터에 수위센서1값 출력
			Serial.println(level1);
			Serial.print("level2:");//시리얼 모니터에 수위센서2값 출력
			Serial.println(level2);
			delay(1000);
		}

		if (digitalRead(switch2Pin) == HIGH) {//스위치를 켰을때)
			digitalWrite(ledPin, HIGH);//적색 LED켜짐
			myservo2.write(0); //배출구 닫힘
			if (level1 == HIGH) {//물이 차지 않았을때
				digitalWrite(ledOn, HIGH); //물 받기 시작
				ledVel = 1;
				myservo2.write(0);
				if (T0 >= 50) {
					myservo1.write(120); // 온도가 50도 이상일때 가장 차가운 물이 나옴
				}
				else if (T0 < 50 && T0 > 40) {
					myservo1.write(75);//온도가 40~50도 일때 차가운 물이 나옴
				}
				else if (T0 <= 40 && T0 > 38) {
					myservo1.write(45);// 온도가 38~40도 일때 적당한 온도의 물이 나옴
				}
				else if (T0 <= 38 && T0 > 25) {
					myservo1.write(15);//온도가 25~38도 일때 따뜻한 물이 나옴
				}
				else {
					myservo1.write(0);//온도가 25도 이하일때 가장 따뜻한 물이 나옴
				}
			}
			//1
			if ((level1 == LOW) && (T0 < 40) && (T0 > 38) && (level2 == 0)) {//적정한 온도로 물이 다 찼을때
				digitalWrite(ledOn, LOW);// 수도꼭지가 꺼짐
				myservo2.write(0);
				ledVel = 0;
			}//2
			if (level2 > 0) {//사람이 들어왔을때
				if ((T0 < 35) && ledVel == 0) {//물의 온도가 35도 이하가 되면
					myservo2.write(90);//배출구 열리고 물이 빠짐
				}
				if (level1 == HIGH) {//일정량의 물이 빠졌을때
					myservo2.write(0);//배출구 닫힘
					digitalWrite(ledOn, HIGH); //수도꼭지가 켜짐
					ledVel = 1;
				}
				if ((level1 == LOW) && ledVel == 1) {//물을 다시 받을때
					myservo2.write(0);
					digitalWrite(ledOn, HIGH);
					ledVel = 1;
					if (T0 >= 50) {
						myservo1.write(120);
					}
					else if (T0 < 50 && T0 > 40) {
						myservo1.write(75);
					}
					else if (T0 <= 40 && T0 >38) {
						myservo1.write(45);
					}
					else if (T0 <= 38 && T0 > 25) {
						myservo1.write(15);
					}
					else {
						myservo1.write(0);
					}
				}
				if (level2>300) {//적정 온도로 물이 다시 받아지면
					digitalWrite(ledOn, LOW);//수도꼭지가 꺼짐
					ledVel = 0;
					myservo2.write(0);
				}
			}//3
		}
		else {//스위치가 꺼지면
			digitalWrite(ledOn, LOW);
			ledVel = 0;
			digitalWrite(ledPin, LOW);//적색LED OFF
			myservo2.write(90);//배출구가 열려 물이 빠짐
		}//4
	}
}

void serialEvent() {
	while (Serial.available()) {
		Re_buf[counter] = (unsigned char)Serial.read();
		if (counter == 0 && Re_buf[0] != 0X5A) return;
		counter++;
		if (counter == 9) {
			counter = 0;
			sign = 1;
		}
	}
}