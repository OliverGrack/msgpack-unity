using MsgPack;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using System.Linq;
using Player.Customization;

public class MsgPackTests : IPrebuildSetup {
    static ObjectPacker packer;

    public void Setup() {
        packer = new ObjectPacker();
    }

    [Test]
    public void Vector3_de_ser_works() {
        Vector3 vec1 = new Vector3(1, 2, 3);
        byte[] vec1_buffer = packer.Pack(vec1);


        Vector3 vec2 = packer.Unpack<Vector3>(vec1_buffer);

        Assert.AreEqual(vec1, vec2);
    }

    private void LogByteStringJsArray(object o) {
        byte[] buffer = packer.Pack(o);
        Debug.Log("[ " + string.Join(", ", buffer.Select(b => (int)b).Select(b => b.ToString()).ToArray()) + " ]");
    }

    [Test]
    public void Logging() {
        LogByteStringJsArray(new PlayerCostumeDTO(new PlayerCostume()));
    }
}
