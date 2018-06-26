// �߼�������
#include <CoreFoundation/CoreFoundation.h>
#ifndef _ROCKEY4_ND_32_
#define _ROCKEY4_ND_32_
//����id
/* ������ʽ:
(1) ������
    �������:
    function = 0
    *p1 = pass1
    *p2 = pass2
    *p3 = pass3
    *p4 = pass4
    ����:
    *lp1 Ϊ����Ӳ�� ID
    ����Ϊ 0 ��ʾ�ɹ�, ����Ϊ������

(2) ������һ��
    �������:
    function = 1
    *p1 = pass1
    *p2 = pass2
    *p3 = pass3
    *p4 = pass4
    ����:
    *lp1 Ϊ����Ӳ�� ID
    ����Ϊ 0 ��ʾ�ɹ�, ����Ϊ������

(3) ����
    �������:
    function = 2
    *p1 = pass1
    *p2 = pass2
    *p3 = pass3
    *p4 = pass4
    *lp1 = Ӳ�� ID
    ����:
    *handle Ϊ���ľ��
    ����Ϊ 0 ��ʾ�ɹ�, ����Ϊ������

(4) �ر���
    �������:
    function = 3
    *handle = ���ľ��
    ����:
    ����Ϊ 0 ��ʾ�ɹ�, ����Ϊ������

(5) ����
    �������:
    function = 4
    *handle = ���ľ��
    *p1 = pos
    *p2 = length
    buffer = ��������ָ��
    ����:
    buffer ��������������
    ����Ϊ 0 ��ʾ�ɹ�, ����Ϊ������

(6) д��
    function = 5
    *handle = ���ľ��
    *p1 = pos
    *p2 = length
    buffer = ��������ָ��
    ����:
    ����Ϊ 0 ��ʾ�ɹ�, ����Ϊ������

(7) �����
    function = 6
    *handle = ���ľ��
    ����:
    *p1,*p2,*p3,*p4 = �����
    ����Ϊ 0 ��ʾ�ɹ�, ����Ϊ������
    
(8) ������
    function = 7
    *handle = ���ľ��
    *lp2 = ������
    ����:
    *p1 = ������1
    *p2 = ������2
    *p3 = ������3
    *p4 = ������4
    ����Ϊ 0 ��ʾ�ɹ�, ����Ϊ������

(9) д�û� ID [*]
    function = 8
    *handle = ���ľ��
    *lp1 = �û� ID
    ����:
    ����Ϊ 0 ��ʾ�ɹ�, ����Ϊ������

(10) ���û� ID
     function = 9
     *handle = ���ľ��
     ����:
     *lp1 = �û� ID
     ����Ϊ 0 ��ʾ�ɹ�, ����Ϊ������

(11) ����ģ�� [*]
     function = 10
     *handle = ���ľ��
     *p1 = ģ���
     *p2 = �û�ģ������
     *p3 = �Ƿ�����ݼ� (1 = ����, 0 = ������)
     ����:
     ����Ϊ 0 ��ʾ�ɹ�, ����Ϊ������

(12) ���ģ���Ƿ���Ч
     function = 11
     *handle = ���ľ��
     *p1 = ģ���
     ����:
     *p2 = 1 ��ʾ��ģ����Ч
     *p3 = 1 ��ʾ��ģ����Եݼ�
     ����Ϊ 0 ��ʾ�ɹ�, ����Ϊ������

(13) д�㷨 [*]
     function = 12
     *handle = ���ľ��
     *p1 = pos
     buffer = �㷨ָ�
     ����:
     ����Ϊ 0 ��ʾ�ɹ�, ����Ϊ������
     
(14) ����1 (ģ����, ID ��λ, ID ��λ, �����)
     function = 13
     *handle = ���ľ��
     *lp1 = ������ʼ��
     *lp2 = ģ���
     *p1 = ����ֵ1
     *p2 = ����ֵ2
     *p3 = ����ֵ3
     *p4 = ����ֵ4
     ����:
     *p1 = ����ֵ1
     *p2 = ����ֵ2
     *p3 = ����ֵ3
     *p4 = ����ֵ4
     ����Ϊ 0 ��ʾ�ɹ�, ����Ϊ������

(15) ����2
     function = 14
     *handle = ���ľ��
     *lp1 = ������ʼ��
     *lp2 = ������
     *p1 = ����ֵ1
     *p2 = ����ֵ2
     *p3 = ����ֵ3
     *p4 = ����ֵ4
     ����:
     *p1 = ����ֵ1
     *p2 = ����ֵ2
     *p3 = ����ֵ3
     *p4 = ����ֵ4
     ����Ϊ 0 ��ʾ�ɹ�, ����Ϊ������

(16) ����3
     function = 15
     *handle = ���ľ��
     *lp1 = ������ʼ��
     *lp2 = ������ʼ��ַ
     *p1 = ����ֵ1
     *p2 = ����ֵ2
     *p3 = ����ֵ3
     *p4 = ����ֵ4
     ����:
     *p1 = ����ֵ1
     *p2 = ����ֵ2
     *p3 = ����ֵ3
     *p4 = ����ֵ4
     ����Ϊ 0 ��ʾ�ɹ�, ����Ϊ������

(17) �ݼ�
     function = 16
     *handle = ���ľ��
     *p1 = ģ���
     ����Ϊ 0 ��ʾ�ɹ�, ����Ϊ������
*/

#define  RY_FIND                        1		//����
#define  RY_FIND_NEXT					2		//����һ��
#define  RY_OPEN                        3		//����
#define  RY_CLOSE                       4		//�ر���
#define  RY_READ                        5		//����
#define  RY_WRITE                       6		//д��
#define  RY_RANDOM                      7		//���������
#define  RY_SEED                        8		//����������
#define  RY_WRITE_USERID				9		//д�û� ID
#define  RY_READ_USERID					10		//���û� ID
#define  RY_SET_MODULE					11		//����ģ����
#define  RY_CHECK_MODULE				12		//���ģ��״̬
#define  RY_WRITE_ARITHMETIC            13		//д�㷨
#define  RY_CALCULATE1					14		//���� 1
#define  RY_CALCULATE2					15		//���� 2
#define  RY_CALCULATE3					16		//���� 3
#define  RY_DECREASE					17		//�ݼ�ģ�鵥Ԫ
#define  RY_CALLNET 					18
#define  RY_SETPASSWORDID               0xf0
#define  RY_AGENTBURN	               	0xf3
#define  RY_GETVERSION					0xf7
//r4 cmd{{
#define RY_WRITENET			19
#define RY_NETBURN			0xf6
#define RY_WRITE_DEVICENAME		0xf2
//}}



// ������
#define ERR_SUCCESS				0 //û�д���
#define ERR_NO_ROCKEY			3 //û��ROCKEY
#define ERR_INVALID_PASSWORD	4 //��ROCKEY���������������
#define ERR_INVALID_PASSWORD_OR_ID	5 //����������Ӳ�� ID
#define ERR_SETID				6 //����Ӳ�� ID ��
#define ERR_INVALID_ADDR_OR_SIZE	7 //��д��ַ�򳤶�����
#define ERR_UNKNOWN_COMMAND		8 //û�д�����
#define ERR_NOTBELEVEL3			9 //�ڲ�����
#define ERR_READ				10 //�����ݴ�
#define ERR_WRITE				11 //д���ݴ�
#define ERR_RANDOM				12 //�������
#define ERR_SEED				13 //�������
#define ERR_CALCULATE			14 //�����
#define ERR_NO_OPEN				15 //�ڲ���ǰû�д���
#define ERR_OPEN_OVERFLOW		16 //�򿪵���̫��(>16)
#define ERR_NOMORE				17 //�Ҳ����������
#define ERR_NEED_FIND			18 //û�� Find ֱ������ FindNext
#define ERR_DECREASE			19 //�ݼ���
#define ERR_AR_BADCOMMAND		20 //�㷨ָ���
#define ERR_AR_UNKNOWN_OPCODE	21 //�㷨�������
#define ERR_AR_WRONGBEGIN		22 //�㷨��һ��ָ��г���
#define ERR_AR_WRONG_END		23 //�㷨���һ��ָ��г���
#define ERR_AR_VALUEOVERFLOW	24 //�㷨�г���ֵ > 63
#define ERR_TOOMUCHTHREAD		25 //ͬһ�������д������߳��� > 100
#define ERR_RECEIVE_NULL		0x100 //���ղ���
#define ERR_UNKNOWN_SYSTEM		0x102 //δ֪�Ĳ���ϵͳ
#define ERR_UNKNOWN				0xffff //δ֪����

#ifdef __cplusplus
#define EXTERN_C    extern "C"
#else
#define EXTERN_C    extern
#endif



EXTERN_C unsigned short Rockey(unsigned short function,unsigned short *handle,unsigned int *lp1,unsigned int *lp2,unsigned short *p1,unsigned short *p2,unsigned short *p3,unsigned short *p4,unsigned char *buffer);
typedef UInt16 (*RockeyPtr)(UInt16 function,UInt16 *handle,UInt32 *lp1,UInt32 *lp2,UInt16 *p1,UInt16 *p2,UInt16 *p3,UInt16 *p4,unsigned char *buffer);
CFBundleRef GetRockey(CFBundleRef theBundle,RockeyPtr* rockeycall);
void FreeRockey(CFBundleRef theBundle,RockeyPtr rockeycall);
#endif
