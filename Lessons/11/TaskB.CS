//B.Have two communication nodes. Let them communicate by using asymmetric RSA encryption. Use TaskB.cs as a foundation.


//Expected output (keys are variable):
//A sending: Hi, I'm A
//A Using peer public key: <RSAKeyValue><Modulus>xTuWNSx4lb70zwRk1bl7SM9Y0fvGzMjwd+GVQ/LL8giKh7Uuhm7fgglKnqRU6fwGNGmVfcNXsJDww9X15Xpp0lG3GrCPENmGLNlk8xHt7621me3Pn2R0V/VPUkNmctnL9AVYXIdQxzHGJDlZh91E3RizPGvB7awvZka7TAji1Oc=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>
//A encrypted: 05,AD,47,21,01,42,2E,96,DE,33,58,3D,90,A3,2B,55,50,74,DE,02,6A,CD,63,B2,D9,44,69,8B,8A,00,56,D7,69,03,EA,CF,CE,8D,EB,E2,0A,F6,7E,F7,EF,E8,FC,2A,57,FF,F7,54,31,F0,27,54,D9,77,4E,22,AB,98,49,3F,6C,6F,9B,A8,F4,33,55,EA,8D,EB,DE,D2,D3,AB,21,A1,BA,B4,65,1E,43,0E,7F,5C,68,58,0F,15,1A,02,6D,7E,AF,98,79,9F,82,26,43,2E,8E,F6,BE,AB,BD,9A,C5,AD,56,DE,EC,FD,7E,94,C6,1E,2F,FC,BF,79,24,A7,19,42
//B Using my private key: <RSAKeyValue><Modulus>xTuWNSx4lb70zwRk1bl7SM9Y0fvGzMjwd+GVQ/LL8giKh7Uuhm7fgglKnqRU6fwGNGmVfcNXsJDww9X15Xpp0lG3GrCPENmGLNlk8xHt7621me3Pn2R0V/VPUkNmctnL9AVYXIdQxzHGJDlZh91E3RizPGvB7awvZka7TAji1Oc=</Modulus><Exponent>AQAB</Exponent><P>3oD8vZ9Be1zoAA05vbCXfgTzpuWL4VPnGoWhB/0wzuoIVeY+QEDPj9yV+XKXO7IQLjNhUyoSLqn9yM/Ju1Iu/Q==</P><Q>4uyvFWc5MRBBeuZpmrfomekxwQ4XPwqrgSFMPmi2MwGN6sHwn+c9MNdV8KuuooO6F57oVbFprHFZlzdYWqYCsw==</Q><DP>pt17LcYKeLbDMo64l96grhyOkcKidbjTn1tJ2dDy0qpG2AzU8KDqSIx4WNusOVOfuNZFjfYGLsLDld7m/jlzDQ==</DP><DQ>EYjIXpcDTE89QAndzx620m26cnhsQ2rHpcq04X2l1nsgRCuINFLh34xED7y0Wcpj7r9QpI544+I+Ufjs0tRREQ==</DQ><InverseQ>AqYubnoyE575pAnk7A/5A3SNjFVLFALHf3qBZWWtH1xKjMwf7lKypPhQDtRZ+qz5b8vg6imnK47YswV/1x5Zqg==</InverseQ><D>GEctRmQFfzqvbCYt0Ah8w6nQ/0lp9L5NVMG+ESGmIie+qarPTHlXEOzaNGylDoeuhILKBd48VpMuLTpoAjSPKZRWkwuOVcdnsKb49Wfa+YaAiU2K6+K+TU8r2oExhoVEbIvFZgaRYwsqbieundaVgUCCXnpISegDJecXHqIfaN0=</D></RSAKeyValue>
//B received: Hi, I'm A

//B sending: Hi, I'm B
//B Using peer public key: <RSAKeyValue><Modulus>p4JxK1dF24QmgFTglrbu7mjCtb5f7J9u7yfszAct6HPwZo6uXabijsLYKsfMOArQIvSjsoiYypIBHklWjSfz6opsmpUKl+0ClRd2pQKgCSWVL8LfWJ3pz6KntyoQ4CA5ipuqU4Jb8WGpL+Pf34Y6tdrjH3dMjYrKgecxkmwPIUM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>
//B encrypted: 34,93,97,C1,76,78,51,CF,A6,A4,36,54,37,1A,5F,2A,EA,FD,96,41,11,F4,69,66,00,57,9A,0E,E1,9D,F5,A9,6E,9E,BC,71,B6,8B,0D,B4,AA,B4,62,DB,02,1F,68,63,BB,C6,3B,E8,87,89,9B,A5,D6,2E,7E,55,C8,1E,EE,00,41,FB,7A,F0,18,89,40,B2,28,E1,78,D4,CF,46,FC,85,F2,19,BE,73,0D,24,5A,4F,63,FC,4E,34,38,A8,EF,5C,A9,EF,A1,48,60,62,C1,76,05,A1,2D,1A,B6,3C,BA,95,C3,1D,E2,92,1A,7F,54,9E,FA,DD,54,CD,F1,D1,D5,6D
//A Using my private key: <RSAKeyValue><Modulus>p4JxK1dF24QmgFTglrbu7mjCtb5f7J9u7yfszAct6HPwZo6uXabijsLYKsfMOArQIvSjsoiYypIBHklWjSfz6opsmpUKl+0ClRd2pQKgCSWVL8LfWJ3pz6KntyoQ4CA5ipuqU4Jb8WGpL+Pf34Y6tdrjH3dMjYrKgecxkmwPIUM=</Modulus><Exponent>AQAB</Exponent><P>403LvjeTZ6K4gJS/RwPCwCw+zKuO607mGco3CvFJdlssoRU7Dk2t4j0b3CF3H5Xw/mSjQM0MARKVSOF+GIldsw==</P><Q>vKgpGVKrBrmPdC1uAr6EP6Pi22RcWC936Wl9viRz7jgi2bHNKwtrfFYrxe/iTpHG6Sfo4Fv7psSbbKJigyYGMQ==</Q><DP>PC3RnlfKb+q13F0FU0Dco9JTAg79tLDb3MIb1orRP0OeSjt7uiq4uagiIyK9DiC9gCyWyEZBQltwKK6Cmu5rXw==</DP><DQ>DgBtDHQWPWmIPBcjExEQv6hqLd5E/EaJn8k0i+gosoV4ELAhihBO6et7VDV5lls7aBKONhidlMMCxg1HQnSQAQ==</DQ><InverseQ>PPd/9bNCuFqUyrAa65uEH3xsfvsh+i7dgeMh2d3USfiz8Oxw86SUvwFGQeS+3aM4PnbyQ/vI1uAzxcyYaAfZbg==</InverseQ><D>KeWueLCzgFxlZOPV6NyIlokNanfbdkvKa3cI+18wVFvrXTuC0VnUgPCrMMgYhEvwE04tQ5J25PPv46tkQpojn7ZFRt9HIxtSbSipCujqTo0z5HtANpHPHfRMB+xJ5D4bLd7j+wif9XeQGy+agF+1IF+k3+VDrVE+mqhaUYdU6wE=</D></RSAKeyValue>
//A received: Hi, I'm B

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace Lessons._11.Tasks
{
    public class TaskB
    {
        public static void Run()
        {
            var nodeA = new Node("A");
            var nodeB = new Node("B");
            nodeA.Send(nodeB, "Hi, I'm A");
            nodeB.Send(nodeA, "Hi, I'm B");
            Waiter.WaitForAnyKey();
        }
    }

    public class Node
    {
        private readonly string _name;
        public readonly XDocument _publicKey;
        public readonly XDocument _privateKey;

        public Node(string name)
        {
            _name = name;
            //
        }

        public void Send(Node peerNode, string message)
        {
            //todo
        }

        private void Receive(byte[] encrypted)
        {
            //todo
        }
    }

    public static class ByteToStringConverter
    {
        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
