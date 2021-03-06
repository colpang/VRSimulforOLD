﻿using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Linq;
using UnityEngine.UI;
using System;

public class SocketServer : MonoBehaviour
{

    Thread m_socketThread;
    volatile bool m_keepReading = false;

    Socket listener;
    Socket handler;

    void Start()
    {
        Application.runInBackground = true;
        startServer();

    }

    void startServer()
    {
        m_socketThread = new System.Threading.Thread(networkCode);
        m_socketThread.IsBackground = true;
        m_socketThread.Start();
    }

    private string getIPAddress()
    {
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
            }

        }
        return localIP;
    }

    void networkCode()
    {

        byte[] bytes = null;

        // host running the application.
        Debug.Log("Ip " + getIPAddress().ToString());
        IPAddress[] ipArray = Dns.GetHostAddresses(getIPAddress());
        IPEndPoint localEndPoint = new IPEndPoint(ipArray[0], 1755);

        // Create a TCP/IP socket.
        listener = new Socket(ipArray[0].AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);

        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(10);

            // Start listening for connections.
            while (true)
            {
                m_keepReading = true;

                // Program is suspended while waiting for an incoming connection.
                Debug.Log("Waiting for Connection");
                handler = listener.Accept();
                Debug.Log("Client Connected");

                // An incoming connection needs to be processed.
                while (m_keepReading)
                {
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);


                    ////////////////////////
                    // use bytes, bytesRec



                    if (bytesRec <= 0)
                    {
                        m_keepReading = false;
                        handler.Disconnect(true);
                        break;
                    }

                    if (bytesRec < bytes.Length)
                    {
                        //isRefresh = true;

                        break;
                    }

                    System.Threading.Thread.Sleep(1);
                }

                System.Threading.Thread.Sleep(1);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    void stopServer()
    {
        m_keepReading = false;

        //stop thread
        if (m_socketThread != null)
        {
            m_socketThread.Abort();
        }

        if (handler != null && handler.Connected)
        {
            handler.Disconnect(false);
            Debug.Log("Disconnected!");
        }
    }

    void OnDisable()
    {
        stopServer();
    }

}
