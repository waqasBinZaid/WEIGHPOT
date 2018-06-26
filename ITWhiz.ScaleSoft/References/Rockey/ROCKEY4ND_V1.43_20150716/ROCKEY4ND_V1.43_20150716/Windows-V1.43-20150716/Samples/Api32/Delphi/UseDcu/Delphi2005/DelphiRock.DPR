program DelphiRock;

uses
  Forms,
  Main in 'MAIN.PAS' {MainForm};

{$R *.RES}

begin
  Application.Title := 'Rockey4ND Test';
  Application.CreateForm(TMainForm, MainForm);
  Application.Run;
end.
