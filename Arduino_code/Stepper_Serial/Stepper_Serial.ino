int dirPin = 8;
int stepperPin = 9;
double pos = 0;
void setup() {
 pinMode(dirPin, OUTPUT);
 pinMode(stepperPin, OUTPUT);
 Serial.begin(9600);
}

void loop(){
  if(Serial.available() > 0)
  {
    String command = Serial.readStringUntil('#');
    //Serial.println(command);
    if(command.equals("reset"))
    {
      step(false,pos);
      pos = 0;
    }
    if(command.startsWith("set"))
    {
      int newpos = (command.substring(3,command.length()).toInt());
      int dis = newpos-pos;
      if(dis >0)
      {
        step(true,dis);
        pos = newpos;
      }
      if( dis < 0)
      {
        step(false,abs(dis));
        pos = newpos;
      }
      //Serial.print("POSITION: ");
      //Serial.println(pos);
    }
    if(command.startsWith("pos"))
    {
      pos = (command.substring(3,command.length()).toInt());
    }
  }
}

void step(boolean dir,double steps)
{
 digitalWrite(dirPin,dir);
 delay(50);
 for(int i=0;i<steps;i++)
 {
   digitalWrite(stepperPin, HIGH);
   delayMicroseconds(800);
   digitalWrite(stepperPin, LOW);
   delayMicroseconds(800);
   pos++;
 }
}
