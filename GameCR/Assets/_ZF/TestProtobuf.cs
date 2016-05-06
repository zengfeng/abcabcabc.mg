using UnityEngine;
using System.Collections;
using System.IO;
using ProtoBuf;

namespace test.protobuf
{
	[ProtoContract]
	class Person {
		[ProtoMember(1)]
		public int Id {get;set;}
		[ProtoMember(2)]
		public string Name { get; set;}
		[ProtoMember(3)]
		public Address Address {get;set;}

		public override string ToString ()
		{
			return string.Format ("[Person: Id={0}, Name={1}, Address={2}]", Id, Name, Address);
		}
	}

	[ProtoContract]
	class Teacher :  Person
	{
		[ProtoMember(1)]
		public string city { get; set;}

		public override string ToString ()
		{
			return string.Format ("[Teacher: city={0}  base:={1}]", city, base.ToString());
		}

	}

	[ProtoContract]
	class Address {
		[ProtoMember(1)]
		public string Line1 {get;set;}
		[ProtoMember(2)]
		public string Line2 {get;set;}

		public override string ToString ()
		{
			return string.Format ("[Address: Line1={0}, Line2={1}]", Line1, Line2);
		}
	}

	public class TestProtobuf : MonoBehaviour 
	{

		// Use this for initialization
		void Start () {
		
		
		}

		public void Save()
		{
			Address address = new Address();
			address.Line1 = "AAAAA";
			address.Line2 = "BBBBBB";

			Teacher person = new Teacher ();
			person.Id = 1;
			person.Name = "ZengFeng";
			person.Address = address;
			person.city = "ShangHai";

			Person p = person;

			using (var file = File.Create("person.bin"))
			{
				Serializer.Serialize(file, p);
			}

		}

		public void Read()
		{
			Teacher newPerson;
			using (var file = File.OpenRead("person.bin"))
			{
				newPerson = Serializer.Deserialize<Teacher>(file);

				Debug.Log (newPerson);
			}
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}