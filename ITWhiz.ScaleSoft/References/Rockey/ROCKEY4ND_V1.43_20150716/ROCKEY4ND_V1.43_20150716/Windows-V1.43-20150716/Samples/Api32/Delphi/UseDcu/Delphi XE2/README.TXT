Rockey 加密锁Delphi调用指南：
以下常量已在Rockey4ND.dcu中定义，可直接使用：

RY_FIND                        	=1 ;		{找锁}
RY_FIND_NEXT		        =2 ;		{找下一锁}
RY_OPEN                        	=3 ;		{打开锁}
RY_CLOSE                       	=4 ;		{关闭锁}
RY_READ                        	=5 ;		{读锁}
RY_WRITE                       	=6 ;		{写锁}
RY_RANDOM                      	=7 ;		{产生随机数 }
RY_SEED                      	=8 ;		{产生种子码 }
RY_WRITE_USERID			=9 ;		{写用户 ID  }
RY_READ_USERID		   	=10;		{读用户 ID  }
RY_SET_MOUDLE		        =11;		{设置模块字 }
RY_CHECK_MOUDLE		        =12;		{检查模块状态}
RY_WRITE_ARITHMETIC            	=13;		{写算法 }
RY_CALCULATE1		       	=14;		{计算 1 }
RY_CALCULATE2		       	=15;		{计算 2 }
RY_CALCULATE3		       	=16;		{计算 3 }
RY_DECREASE		       	=17;		{递减模块单元 }
{错误码}

{错误码}
R4NDERR_NO_ROCKEY	                =3;		{没有 Rockey 锁}
R4NDERR_INVALID_PASSWORD		=4;		{有 Rockey 锁, 但基本密码(pass1, pass2)错}
R4NDERR_INVALID_PASSWORD_OR_ID 	=5;		{错误的密码或硬件 ID }
R4NDERR_SETID			=6;               {设置硬件 ID 错 }
R4NDERR_INVALID_ADDR_OR_SIZE	=7;		{读写地址或长度有误 }
R4NDERR_UNKNOWN_COMMAND        	=8;		{没有此命令}
R4NDERR_NOTBELEVEL3		        =9;		{内部错误 }
R4NDERR_READ			=10;		{读数据错 }
R4NDERR_WRITE                  	=11;		{写数据错 }
R4NDERR_RANDOM                 	=12;		{随机数错 }
R4NDERR_SEED                   	=13;		{种子码错 }
R4NDERR_CALCULATE              	=14;		{计算错   }
R4NDERR_NO_OPEN			=15;		{在操作前没有打开锁  }
R4NDERR_OPEN_OVERFLOW          	=16;		{打开的锁太多(>16)   }
R4NDERR_NOMORE			=17;		{找不到更多的锁      }
R4NDERR_NEED_FIND			=18;		{没有 Find 直接用了 FindNext }
R4NDERR_DECREASE			=19;		{递减错          }
R4NDERR_AR_BADCOMMAND		=20;		{算法指令错      }
R4NDERR_AR_UNKNOWN_OPCODE		=21;		{算法运算符错    }
R4NDERR_AR_WRONGBEGIN		=22;		{算法第一条指令含有常数}
R4NDERR_AR_WRONG_END		=23;		{算法最后一条指令含有常数}
R4NDERR_AR_VALUEOVERFLOW		=24;		{算法中常数值 > 63  }
R4NDERR_TOOMUCHTHREAD	 = 25; 		{同一个进程中打开锁的线程数 > 100}
R4NDERR_UNKNOWN			=65535;		{未知错误     }
R4NDERR_RECEIVE_NULL		=256;		{接收不到     }
R4NDERR_UNKNOWN_SYSTEM		=258;		{未知的操作系统}

{ROCKEY加密锁的调用入口}
function  Rockey( fun: Word ;var Handle:Word;var lp1,lp2:LongWord; var P1,P2,P3,P4:Word;var buf:Byte):Word;
///////////////////////////////////////////////////////////////
使用：
在程序的Uses中加入：rockey4nd 。

进程开始时要调用R4ND_Init();初始化库
进程推出前调用R4ND_Finish();释放资源

参数的调用：
fun可以用数字或RY_XXXXX,其它都必须传入变量，最后一个参数你可能想传入字符串
,您应当把它拷到一个Byte数组中。例如：
 cstr:='H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D';
  for i:=0 to strlen(cstr) do
      mBuf[i]:= Byte(cstr[i]);
  mBuf[i]:=0;
  mFun:=RY_WRITE_ARITHMETIC;
  mP1:=0;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
 ............

具体看例子程序。
