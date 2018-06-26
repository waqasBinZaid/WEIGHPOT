program DelphiRock_XE2;

uses
  Forms,
  Main in 'MAIN.PAS' {MainForm},
  ry4nd in 'ry4nd.pas';

{$R *.RES}

begin
  Application.Title := 'Rockey≤‚ ‘≥Ã–Ú';
  Application.CreateForm(TMainForm, MainForm);
  Application.Run;
end.
