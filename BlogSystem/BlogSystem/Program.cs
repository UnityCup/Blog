const string path = "Build";

if (!Directory.Exists(path)) Directory.CreateDirectory(path);


File.WriteAllText(Path.Join(path, @"test2.html"), "HOGEEEEEEEEEEEEEEEEE");
File.WriteAllText(Path.Join(path, @"index.html"), "this is index.");