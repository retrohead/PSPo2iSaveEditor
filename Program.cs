// Decompiled with JetBrains decompiler
// Type: pspo2seSaveEditorProgram.Program
// Assembly: PSPo2 Save Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E91610F-7D39-4E7C-8F4B-E7C65114B315
// Assembly location: C:\Development\PSPo2 Save Editor v3.0 build 1004 pack\PSPo2 Save Editor.exe

using System;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
  internal static class Program
  {
    public static pspo2seForm thisForm;

    public static pspo2seForm form
    {
      get => Program.thisForm;
      set => Program.thisForm = value;
    }

    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Program.form = new pspo2seForm();
      Application.Run((Form) Program.form);
    }
  }
}
