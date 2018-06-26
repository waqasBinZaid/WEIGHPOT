# Microsoft Developer Studio Generated NMAKE File, Format Version 4.00
# ** DO NOT EDIT **

# TARGTYPE "Win32 (x86) Console Application" 0x0103

!IF "$(CFG)" == ""
CFG=Sample - Win32 Debug
!MESSAGE No configuration specified.  Defaulting to Sample - Win32 Debug.
!ENDIF 

!IF "$(CFG)" != "Sample - Win32 Release" && "$(CFG)" != "Sample - Win32 Debug"
!MESSAGE Invalid configuration "$(CFG)" specified.
!MESSAGE You can specify a configuration when running NMAKE on this makefile
!MESSAGE by defining the macro CFG on the command line.  For example:
!MESSAGE 
!MESSAGE NMAKE /f "Sample.mak" CFG="Sample - Win32 Debug"
!MESSAGE 
!MESSAGE Possible choices for configuration are:
!MESSAGE 
!MESSAGE "Sample - Win32 Release" (based on "Win32 (x86) Console Application")
!MESSAGE "Sample - Win32 Debug" (based on "Win32 (x86) Console Application")
!MESSAGE 
!ERROR An invalid configuration is specified.
!ENDIF 

!IF "$(OS)" == "Windows_NT"
NULL=
!ELSE 
NULL=nul
!ENDIF 
################################################################################
# Begin Project
# PROP Target_Last_Scanned "Sample - Win32 Debug"
RSC=rc.exe
F90=fl32.exe

!IF  "$(CFG)" == "Sample - Win32 Release"

# PROP BASE Use_MFC 0
# PROP BASE Use_Debug_Libraries 0
# PROP Use_MFC 0
# PROP Use_Debug_Libraries 0
OUTDIR=.
INTDIR=.

ALL : "$(OUTDIR)\Sample.exe"

CLEAN : 
	-@erase ".\Sample.exe"
	-@erase ".\Sample.obj"

# ADD BASE F90 /Ox /c /nologo
# ADD F90 /Ox /c /nologo
F90_PROJ=/Ox /c /nologo 
# ADD BASE RSC /l 0x804 /d "NDEBUG"
# ADD RSC /l 0x804 /d "NDEBUG"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
BSC32_FLAGS=/nologo /o"$(OUTDIR)/Sample.bsc" 
BSC32_SBRS=
LINK32=link.exe
# ADD BASE LINK32 kernel32.lib /nologo /subsystem:console /machine:I386
# ADD LINK32 kernel32.lib /nologo /subsystem:console /machine:I386
LINK32_FLAGS=kernel32.lib /nologo /subsystem:console /incremental:no\
 /pdb:"$(OUTDIR)/Sample.pdb" /machine:I386 /out:"$(OUTDIR)/Sample.exe" 
LINK32_OBJS= \
	"$(INTDIR)/Sample.obj"

"$(OUTDIR)\Sample.exe" : "$(OUTDIR)" $(DEF_FILE) $(LINK32_OBJS)
    $(LINK32) @<<
  $(LINK32_FLAGS) $(LINK32_OBJS)
<<

!ELSEIF  "$(CFG)" == "Sample - Win32 Debug"

# PROP BASE Use_MFC 0
# PROP BASE Use_Debug_Libraries 1
# PROP Use_MFC 0
# PROP Use_Debug_Libraries 1
OUTDIR=.
INTDIR=.

ALL : "$(OUTDIR)\Sample.exe"

CLEAN : 
	-@erase ".\Sample.exe"
	-@erase ".\Sample.obj"
	-@erase ".\Sample.ilk"
	-@erase ".\Sample.pdb"

# ADD BASE F90 /Zi /c /nologo
# ADD F90 /Zi /c /nologo
F90_PROJ=/Zi /c /nologo /Fd"Sample.pdb" 
# ADD BASE RSC /l 0x804 /d "_DEBUG"
# ADD RSC /l 0x804 /d "_DEBUG"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
BSC32_FLAGS=/nologo /o"$(OUTDIR)/Sample.bsc" 
BSC32_SBRS=
LINK32=link.exe
# ADD BASE LINK32 kernel32.lib /nologo /subsystem:console /debug /machine:I386
# ADD LINK32 kernel32.lib rockey4ND.obj /nologo /subsystem:console /debug /machine:I386
LINK32_FLAGS=kernel32.lib rockey4ND.obj /nologo /subsystem:console\
 /incremental:yes /pdb:"$(OUTDIR)/Sample.pdb" /debug /machine:I386\
 /out:"$(OUTDIR)/Sample.exe" 
LINK32_OBJS= \
	"$(INTDIR)/Sample.obj"

"$(OUTDIR)\Sample.exe" : "$(OUTDIR)" $(DEF_FILE) $(LINK32_OBJS)
    $(LINK32) @<<
  $(LINK32_FLAGS) $(LINK32_OBJS)
<<

!ENDIF 

.for.obj:
   $(F90) $(F90_PROJ) $<  

.f.obj:
   $(F90) $(F90_PROJ) $<  

.f90.obj:
   $(F90) $(F90_PROJ) $<  

################################################################################
# Begin Target

# Name "Sample - Win32 Release"
# Name "Sample - Win32 Debug"

!IF  "$(CFG)" == "Sample - Win32 Release"

!ELSEIF  "$(CFG)" == "Sample - Win32 Debug"

!ENDIF 

################################################################################
# Begin Source File

SOURCE=.\Sample.for

"$(INTDIR)\Sample.obj" : $(SOURCE) "$(INTDIR)"


# End Source File
# End Target
# End Project
################################################################################
