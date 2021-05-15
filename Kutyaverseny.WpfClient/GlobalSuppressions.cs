// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "<IDK>", Scope = "type", Target = "~T:Kutyaverseny.WpfClient.MainLogic")]
[assembly: SuppressMessage("Usage", "CA2234:Pass system uri objects instead of strings", Justification = "<IDk>", Scope = "member", Target = "~M:Kutyaverseny.WpfClient.MainLogic.ApiDelDog(Kutyaverseny.WpfClient.DogVM)")]
[assembly: SuppressMessage("Usage", "CA2234:Pass system uri objects instead of strings", Justification = "<IDk>", Scope = "member", Target = "~M:Kutyaverseny.WpfClient.MainLogic.ApiGetDogs~System.Collections.Generic.List{Kutyaverseny.WpfClient.DogVM}")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "<WHAT>", Scope = "member", Target = "~M:Kutyaverseny.WpfClient.MainLogic.ApiDelDog(Kutyaverseny.WpfClient.DogVM)")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "<WHAAT>", Scope = "member", Target = "~M:Kutyaverseny.WpfClient.MainLogic.ApiEditDog(Kutyaverseny.WpfClient.DogVM,System.Boolean)~System.Boolean")]
[assembly: SuppressMessage("Usage", "CA2234:Pass system uri objects instead of strings", Justification = "<NOTNEED>", Scope = "member", Target = "~M:Kutyaverseny.WpfClient.MainLogic.ApiEditDog(Kutyaverseny.WpfClient.DogVM,System.Boolean)~System.Boolean")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<NOTNEED>", Scope = "member", Target = "~M:Kutyaverseny.WpfClient.MainLogic.ApiEditDog(Kutyaverseny.WpfClient.DogVM,System.Boolean)~System.Boolean")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<needFOrmethod>", Scope = "member", Target = "~P:Kutyaverseny.WpfClient.MainVM.AllDogs")]
