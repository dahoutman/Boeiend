; Boeiend.nsi
;

;--------------------------------

; The name of the installer
Name "Boeiend"

; The file to write
OutFile "Boeiend.exe"

; The default installation directory
InstallDir $PROGRAMFILES\Boeiend

; Request application privileges for Windows Vista
RequestExecutionLevel admin

;--------------------------------

; Pages

Page directory
Page instfiles

;--------------------------------

; The stuff to install 
Section "" ;No components page, name is not important

; Set output path to the installation directory.
SetOutPath $INSTDIR
  
; Put file there
File ..\bin\Debug\Boeiend-setup.exe
File ..\Symbols\Betonning.zip
;  File "d:\Temp\Types en Profiel.w5db"

; shortcut for all users
SetShellVarContext all
createShortCut "$SMPROGRAMS\Boeiend.lnk" "$INSTDIR\Boeiend.exe"
  
SectionEnd ; end the section
