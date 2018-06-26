       $set case
      ****************************************************************
      *                                                              *
      * Copyright (C) 2001-2007 Feitian Technologies Co.,Ltd.        *
      *                                                              *
      ****************************************************************
       identification division.
       program-id. RockeyExample.

      ****************************************************************
      *                                                              *
      *                      RockeyExample.BCL                       *
      *                                                              *
      *                                                              *
      * Copyright (C) 2001-2007 Feitian Technologies Co.,Ltd.        *
      *                                                              *
      ****************************************************************
       data division.
       working-storage section.
      ****************************************************************
      * THE ROCKEY CONST VALUE
      ****************************************************************
       78 RY-FIND               value 1.
       78 RY-FIND-NEXT          value 2.
       78 RY-OPEN               value 3.
       78 RY-CLOSE              value 4.
       78 RY-READ               value 5.
       78 RY-WRITE              value 6.
       78 RY-RANDOM             value 7.
       78 RY-SEED               value 8.
       78 RY-WRITE-USERID       value 9.
       78 RY-READ-USERID        value 10.
       78 RY-SET-MOUDLE         value 11.
       78 RY-CHECK-MOUDLE       value 12.
       78 RY-WRITE-ARITHMETIC   value 13.
       78 RY-CALCULATE1         value 14.
       78 RY-CALCULATE2         value 15.
       78 RY-CALCULATE3         value 16.
       78 RY-DECREASE           value 17.
       78 ERR-SUCCESS           value 0.


      ****************************************************************
      * THE PROGRAM VARIANT VALUE
      ****************************************************************
       01 ret                   pic 9(4)  comp-5.
       01 handle                pic 9(4)  comp-5.
       01 p1                    pic 9(4)  comp-5.
       01 p2                    pic 9(4)  comp-5.
       01 p3                    pic 9(4)  comp-5.
       01 p4                    pic 9(4)  comp-5.
       01 lp1                   pic 9(9)  comp-5.
       01 lp2                   pic 9(9)  comp-5.
       01 buf                   pic x(2048).

       01 dllHandle             procedure-pointer.
       01 junk                  pic x.
       procedure division.

      ****************************************************************
      * LOAD THE DLL
      ****************************************************************
        set dllHandle to entry "Rockey4ND.dll".
        if  dllHandle not = null
           move h"c44c" to p1
           move h"c8f8" to p2
           move h"0799" to p3
           move h"c43b" to p4
           display "begin test the rockey..."

      ****************************************************************
      * FIND THE FIRST ROCKEY
      ****************************************************************
           call "Rockey"
                using by value RY-FIND
                      by reference handle
                      by reference lp1
                      by reference lp2
                      by reference p1
                      by reference p2
                      by reference p3
                      by reference p4
                      by reference buf
                      returning ret

           display "Find from rockey, ret is " ret
      ****************************************************************
      * OPEN THE ROCKEY WITH JUST FOUND
      ****************************************************************
           call "Rockey"
                using by value RY-OPEN
                      by reference handle
                      by reference lp1
                      by reference lp2
                      by reference p1
                      by reference p2
                      by reference p3
                      by reference p4
                      by reference buf
                      returning ret
           display "Open from rockey, ret is " ret
      ****************************************************************
      * WRITE THE DATA INTO ROCKEY
      ****************************************************************
           move 0   to p1
           move 20  to p2
           move 'HELLO ROCKEY' to buf


           call "Rockey"
                using by value RY-WRITE
                      by reference handle
                      by reference lp1
                      by reference lp2
                      by reference p1
                      by reference p2
                      by reference p3
                      by reference p4
                      by reference buf
                      returning ret

           display "Write from rockey, buf is " buf (1:20)

      ****************************************************************
      * READ THE DATA FROM ROCKEY
      ****************************************************************
           move 0   to p1
           move 20  to p2
           move "                   " to buf
           call "Rockey"
                  using by value RY-READ
                        by reference handle
                        by reference lp1
                        by reference lp2
                        by reference p1
                        by reference p2
                        by reference p3
                        by reference p4
                        by reference buf
                        returning ret

           display "Read from rockey, ret is " ret

      ****************************************************************
      * GENERATE THE RANDOM NUMBER FROM ROCKEY
      ****************************************************************
          call "Rockey"
                  using by value RY-RANDOM
                        by reference handle
                        by reference lp1
                        by reference lp2
                        by reference p1
                        by reference p2
                        by reference p3
                        by reference p4
                        by reference buf
                        returning ret

           display "Random from rockey, random is " p1
      ****************************************************************
      * GENERATE THE SEED FROM ROCKEY
      ****************************************************************
           move h"12345678" to lp2
           call "Rockey"
                  using by value RY-SEED
                        by reference handle
                        by reference lp1
                        by reference lp2
                        by reference p1
                        by reference p2
                        by reference p3
                        by reference p4
                        by reference buf
                        returning ret

           display "Seed from rockey, is " p1,",",p2,",",p3,",",p4
      ****************************************************************
      * WRITE THE USER ID INTO ROCKEY
      ****************************************************************
           move h"88888888" to lp1
           call "Rockey"
                  using by value RY-WRITE-USERID
                        by reference handle
                        by reference lp1
                        by reference lp2
                        by reference p1
                        by reference p2
                        by reference p3
                        by reference p4
                        by reference buf
                        returning ret
      ****************************************************************
      * READ THE USER ID FROM ROCKEY
      ****************************************************************
          move 0 to lp1
          call "Rockey"
                  using by value RY-READ-USERID
                        by reference handle
                        by reference lp1
                        by reference lp2
                        by reference p1
                        by reference p2
                        by reference p3
                        by reference p4
                        by reference buf
                        returning ret


          display "Read UserID from rockey, is " lp1

      ****************************************************************
      * DOING MODULE OPERATORS WITH ROCKEY
      ****************************************************************
           move 7     to p1
           move h"1"  to p2
           move 0     to p3
           call "Rockey"
                  using by value RY-SET-MOUDLE
                        by reference handle
                        by reference lp1
                        by reference lp2
                        by reference p1
                        by reference p2
                        by reference p3
                        by reference p4
                        by reference buf
                        returning ret
           display "Set Moudle 7: Pass = " p2 ," Decrease no allow "

           move 7     to p1
           call "Rockey"
                  using by value RY-DECREASE
                        by reference handle
                        by reference lp1
                        by reference lp2
                        by reference p1
                        by reference p2
                        by reference p3
                        by reference p4
                        by reference buf
                        returning ret

           move 7     to p1
           call "Rockey"
                  using by value RY-CHECK-MOUDLE
                        by reference handle
                        by reference lp1
                        by reference lp2
                        by reference p1
                        by reference p2
                        by reference p3
                        by reference p4
                        by reference buf
                        returning ret
           display "Check Moudle 7 allow : " p2 , " ; CanDec : " p3

      ****************************************************************
      * DOING SIMPLE ARITHMETIC OPERATORS WHITH ROCKEY
      ****************************************************************
          move 10   to p1
          move
           "A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H" & x"00"
           to buf
          display buf (1:50)
          call "Rockey"
                  using by value RY-WRITE-ARITHMETIC
                        by reference handle
                        by reference lp1
                        by reference lp2
                        by reference p1
                        by reference p2
                        by reference p3
                        by reference p4
                        by reference buf
                        returning ret
           display "Write Arithmetic , ret is " ret

           move 10  to lp1
           move h"12345678"   to lp2
           move 1   to p1
           move 2   to p2
           move 3   to p3
           move 4   to p4
           call "Rockey"
                  using by value RY-CALCULATE2
                        by reference handle
                        by reference lp1
                        by reference lp2
                        by reference p1
                        by reference p2
                        by reference p3
                        by reference p4
                        by reference buf
                        returning ret
           display "Calculate Output:" p1,",",p2,",",p3,",",p4

      ****************************************************************
      *  CLOSE THE ROCKEY
      ****************************************************************
           call "Rockey"
                  using by value RY-CLOSE
                        by reference handle
                        by reference lp1
                        by reference lp2
                        by reference p1
                        by reference p2
                        by reference p3
                        by reference p4
                        by reference buf
                        returning ret

           display "Close from rockey, ret is " ret


           display "Pass any key to close"
           accept junk

         else

           display "failed to load Rockey4ND.dll"

         end-if.



       stop run.
