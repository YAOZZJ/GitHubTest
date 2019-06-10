using System;
using System.IO.Ports;
using System.Diagnostics;
class program
{
    //SerialPort sp = null;
    static void Main()
    {
        SerialPort sp = new SerialPort();
        UsrSerialPortOpen(sp);
        UsrSerialPortSendData(sp,"Hello World");
        Console.ReadKey();
    }
    private static bool UsrSerialPortOpen(SerialPort sp)
    {
        try
        {
            sp.PortName = "COM1";
            sp.BaudRate = 9600;
            sp.DataBits = 8;
            sp.StopBits = StopBits.One;
            sp.Parity = Parity.None;
            sp.Open();
        }
        catch (Exception exp)
        {
            Debug.WriteLine(exp);
        }
        if(sp.IsOpen)
        {
            sp.DataReceived += new SerialDataReceivedEventHandler(UsrSerialPortRecvData);
        }
        return sp.IsOpen;
    }
    private static void UsrSerialPortClose(SerialPort sp)
    {
        sp.Close();
    }
    private static void UsrSerialPortSendData(SerialPort sp,String data)
    {
        sp.Write(data);
    }
    private static void UsrSerialPortRecvData(
                        object sender,
                        SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        Console.Clear();
        Console.WriteLine(sp.ReadExisting());
    }
}