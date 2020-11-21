// Decompiled with JetBrains decompiler
// Type: CSEncryptDecrypt.encryptRoutineType
// Assembly: PSPo2 Save Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E91610F-7D39-4E7C-8F4B-E7C65114B315
// Assembly location: C:\Development\PSPo2 Save Editor v3.0 build 1004 pack\PSPo2 Save Editor.exe

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace CSEncryptDecrypt
{
  public class encryptRoutineType
  {
    [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
    public static extern bool ZeroMemory(IntPtr Destination, int Length);

    public string GenerateKey() => Encoding.ASCII.GetString(DES.Create().Key);

    public CryptoStream createDecryptionReadStream(string sKey, FileStream fs)
    {
      DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
      cryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
      cryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);
      ICryptoTransform decryptor = cryptoServiceProvider.CreateDecryptor();
      return new CryptoStream((Stream) fs, decryptor, CryptoStreamMode.Read);
    }

    public void EncryptFile(
      string sInputFilename,
      string sOutputFilename,
      string sKey,
      GCHandle gch)
    {
      FileStream fileStream1 = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
      FileStream fileStream2 = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);
      DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
      cryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
      cryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);
      ICryptoTransform encryptor = cryptoServiceProvider.CreateEncryptor();
      CryptoStream cryptoStream = new CryptoStream((Stream) fileStream2, encryptor, CryptoStreamMode.Write);
      byte[] buffer = new byte[fileStream1.Length];
      fileStream1.Read(buffer, 0, buffer.Length);
      cryptoStream.Write(buffer, 0, buffer.Length);
      cryptoStream.Close();
      fileStream1.Close();
      fileStream2.Close();
      encryptRoutineType.ZeroMemory(gch.AddrOfPinnedObject(), sKey.Length * 2);
      gch.Free();
    }

    public void DecryptFile(
      string sInputFilename,
      string sOutputFilename,
      string sKey,
      GCHandle gch)
    {
      DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
      cryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
      cryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);
      CryptoStream cryptoStream = new CryptoStream((Stream) new FileStream(sInputFilename, FileMode.Open, FileAccess.Read), cryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Read);
      StreamWriter streamWriter = new StreamWriter(sOutputFilename);
      streamWriter.Write(new StreamReader((Stream) cryptoStream).ReadToEnd());
      streamWriter.Flush();
      streamWriter.Close();
      encryptRoutineType.ZeroMemory(gch.AddrOfPinnedObject(), sKey.Length * 2);
      gch.Free();
    }
  }
}
