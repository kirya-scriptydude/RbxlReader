using RbxlReader;

Place myPlace = new(@"C:\Users\sbox\Documents\Baseplate.rbxl");
Console.WriteLine(myPlace.Rbxl.FileHeader.ClassCount);
Console.WriteLine(myPlace.Rbxl.FileHeader.InstanceCount);