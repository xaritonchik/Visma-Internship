//Created by: Edvin Orlovski
//Date: 2022/17/02 2:00:00 PM

using Newtonsoft.Json;

string command, login, password;
int i = 0;
string[] command_list = { "add", "create", "delete", "exit", "help", "list", "remove" };
string[] logins = { "EdvinOrlovski", "JonasJonaitis", "admin" };
string[] passwords = { "qwerty123", "wasd105", "admin" };
string[] categories = { "CodeMonkey", "Hub", "Short", "TeamBuilding" };
string[] types = { "InPerson", "Live" };
string[] meeting_info = { "", "", "", "", "", "", "" };
bool exit = false;
bool logged = false;

Console.ForegroundColor = ConsoleColor.Red;

Console.WriteLine("/////////////////////////////////////////////////////");
Console.WriteLine("/                                                   /");
Console.WriteLine("/               Visma Meeting Manager               /");
Console.WriteLine("/                                                   /");
Console.WriteLine("/////////////////////////////////////////////////////");
Console.WriteLine("/                                                   /");

// Logging in
while (logged != true)
{

	Console.Write("/ Login: ");
	login = Console.ReadLine();
	Console.WriteLine("/                                                   /");
	Console.Write("/ Password: ");
	password = Console.ReadLine();

	foreach (string element1 in logins)
	{

		if (login == element1)
		{

			if (password == passwords[i])
			{

				Console.WriteLine("/                                                   /");
				Console.WriteLine("/////////////////////////////////////////////////////");
				Console.WriteLine("/                                                   /");
				Console.WriteLine("/               Welcome " + login);
				Console.WriteLine("/                                                   /");
				Console.WriteLine("/////////////////////////////////////////////////////");
				Console.WriteLine("/                                                   /");
				Program();
				logged = true;
				i = 0;
				break;
			}

			else
			{

				Console.WriteLine("/                                                   /");
				Console.WriteLine("/////////////////////////////////////////////////////");
				Console.WriteLine("/                                                   /");
				Console.WriteLine("/          Login or password was incorrect          /");
				Console.WriteLine("/                                                   /");
				Console.WriteLine("/////////////////////////////////////////////////////");
				Console.WriteLine("/                                                   /");
				i = 0;
				break;
			}
		}

		i++;

		if (i == logins.Length)
		{

			Console.WriteLine("/                                                   /");
			Console.WriteLine("/////////////////////////////////////////////////////");
			Console.WriteLine("/                                                   /");
			Console.WriteLine("/          Login or password was incorrect          /");
			Console.WriteLine("/                                                   /");
			Console.WriteLine("/////////////////////////////////////////////////////");
			Console.WriteLine("/                                                   /");
			i = 0;
			break;
		}
	}
}

// Starting program if login successfully
void Program()
{
	Console.WriteLine("/        Insert appropriate command to begin        /");
	Console.WriteLine("/           Type help for list of commands          /");
	Console.WriteLine("/                                                   /");
	Console.WriteLine("/////////////////////////////////////////////////////");
	Console.WriteLine("/                                                   /");
	Console.Write("/ ");
	command = Console.ReadLine();
	Console.WriteLine("/                                                   /");

	while (exit != true)
	{

		switch (command)
		{

			// 'help' will show list of possible commands
			case "help":

				Console.WriteLine("/////////////////////////////////////////////////////");
				Console.WriteLine("/                                                   /");
				Console.WriteLine("/             List of possible commands             /");
				Console.WriteLine("/                                                   /");
				Console.WriteLine("/--------------------           --------------------/");
				Console.WriteLine("/                                                   /");

				// Prints out commands from command_list variable
				foreach (string element in command_list)
				{

					if (element == "add")
					{
						Console.WriteLine("/ " + element + "                                               /");
					}

					else if (element == "create")
					{
						Console.WriteLine("/ " + element + "                                            /");
					}

					else if (element == "delete")
					{
						Console.WriteLine("/ " + element + "                                            /");
					}

					else if (element == "exit")
					{
						Console.WriteLine("/ " + element + "                                              /");
					}

					else if (element == "help")
					{
						Console.WriteLine("/ " + element + "                                              /");
					}

					else if (element == "list")
					{
						Console.WriteLine("/ " + element + "                                              /");
					}

					else if (element == "remove")
					{
						Console.WriteLine("/ " + element + "                                            /");
					}
				}

				Console.WriteLine("/                                                   /");
				Console.WriteLine("/////////////////////////////////////////////////////");
				Console.WriteLine("/                                                   /");
				Console.Write("/ ");
				command = Console.ReadLine();
				break;

			// 'create' will ask for name of meeting, it's description, category, type start and end date
			// to create a new meeting and save it's information to .json file
			case "create":

				Console.WriteLine("/////////////////////////////////////////////////////");
				List<MeetingData> meeting_data = new List<MeetingData>();
				string name, responsible, description, category, type;
				DateTime start_date = new DateTime();
				DateTime end_date = new DateTime();
				string start, end;
				bool category_bool = false;
				bool type_bool = false;

				// Gathers meeting's name
				while (true)
				{

					Console.WriteLine("/                                                   /");
					Console.Write("/ Name of meeting: ");
					name = Console.ReadLine();
					if (name != null)
					{

						Console.WriteLine("/                                                   /");
						meeting_info[0] = name;
						break;
					}

					else
					{
						Console.WriteLine("/                                                   /");
						Console.WriteLine("/             This field can't be empty             /");
					}
				}

				// Responsible person will always be the person who is logged in
				responsible = login;
				meeting_info[1] = responsible;

				// Gathers meeting's description
				while (true)
				{

					Console.Write("/ Description of meeting: ");
					description = Console.ReadLine();
					if (description != null)
					{

						Console.WriteLine("/                                                   /");
						meeting_info[2] = description;
						break;
					}

					else
					{
						Console.WriteLine("/                                                   /");
						Console.WriteLine("/             This field can't be empty             /");
					}
				}

				// Gathers meeting's category
				while (category_bool != true)
				{

					i = 0;
					Console.Write("/ Category of meeting: ");
					category = Console.ReadLine();

					foreach (string element in categories)
					{

						if (category == element)
						{

							Console.WriteLine("/                                                   /");
							meeting_info[3] = category;
							category_bool = true;
							i = 0;
							break;
						}

						if (i == categories.Length - 1)
						{

							Console.WriteLine("/                                                   /");
							Console.WriteLine("/             There is no such category             /");
							Console.WriteLine("/                                                   /");
							Console.WriteLine("/            List of possible categories            /");
							Console.WriteLine("/                                                   /");

							foreach (string element2 in categories)
							{

								if (element2 == "CodeMonkey")
								{

									Console.WriteLine("/ " + element2 + "                                        /");
								}

								else if (element2 == "Hub")
								{

									Console.WriteLine("/ " + element2 + "                                               /");
								}

								else if (element2 == "Short")
								{

									Console.WriteLine("/ " + element2 + "                                             /");
								}

								else if (element2 == "TeamBuilding")
								{

									Console.WriteLine("/ " + element2 + "                                      /");
								}

							}

							Console.WriteLine("/                                                   /");
							break;
						}

						i++;
					}
				}

				// Gathers meeting's type
				while (type_bool != true)
				{

					i = 0;
					Console.Write("/ Type of meeting: ");
					type = Console.ReadLine();

					foreach (string element in types)
					{

						if (type == element)
						{

							Console.WriteLine("/                                                   /");
							meeting_info[4] = type;
							type_bool = true;
							i = 0;
							break;
						}

						if (i == types.Length - 1)
						{

							Console.WriteLine("/                                                   /");
							Console.WriteLine("/               There is no such type               /");
							Console.WriteLine("/                                                   /");
							Console.WriteLine("/               List of possible types              /");
							Console.WriteLine("/                                                   /");

							foreach (string element2 in types)
							{

								if (element2 == "Live")
								{

									Console.WriteLine("/ " + element2 + "                                              /");
								}

								else if (element2 == "InPerson")
								{

									Console.WriteLine("/ " + element2 + "                                          /");
								}

							}

							Console.WriteLine("/                                                   /");
							break;
						}

						i++;
					}
				}

				// Gathers meeting's start date
				while (true)
				{

					Console.WriteLine("/      Date format: MM/DD/YYYY hh:mm:ss AM|PM       /");
					Console.WriteLine("/                                                   /");
					Console.Write("/ Start date of meeting: ");
					start = Console.ReadLine();

					var isValidDate = DateTime.TryParse(start, out start_date);

					if (isValidDate && start_date > DateTime.Now && start != null)
					{

						Console.WriteLine("/                                                   /");
						meeting_info[5] = start;
						break;
					}

					else if (start_date <= DateTime.Now)
					{

						Console.WriteLine("/                                                   /");
						Console.WriteLine("/                 Inappropriate date                /");
						Console.WriteLine("/                                                   /");
					}

					else
					{

						Console.WriteLine("/                                                   /");
						Console.WriteLine("/  Incorrect date format or something out of range  /");
						Console.WriteLine("/                                                   /");
					}
				}

				// Gathers meeting's end date
				while (true)
				{

					Console.WriteLine("/      Date format: MM/DD/YYYY hh:mm:ss AM|PM       /");
					Console.WriteLine("/                                                   /");
					Console.Write("/ End date of meeting: ");
					end = Console.ReadLine();

					var isValidDate = DateTime.TryParse(end, out end_date);

					if (isValidDate && end_date > start_date && end != null)
					{

						Console.WriteLine("/                                                   /");
						meeting_info[6] = end;
						break;
					}

					else if (end_date <= start_date)
					{

						Console.WriteLine("/                                                   /");
						Console.WriteLine("/                 Inappropriate date                /");
						Console.WriteLine("/                                                   /");
					}

					else
					{

						Console.WriteLine("/                                                   /");
						Console.WriteLine("/  Incorrect date format or something out of range  /");
						Console.WriteLine("/                                                   /");
					}
				}

				// Adds all inforamtion to class
				meeting_data.Add(new MeetingData()
				{

					Name = meeting_info[0],
					Responsible_person = meeting_info[1],
					Description = meeting_info[2],
					Category = meeting_info[3],
					Type = meeting_info[4],
					Start_date = meeting_info[5],
					End_date = meeting_info[6]
				});

				// Serializes class to string
				string json = System.Text.Json.JsonSerializer.Serialize(meeting_data);

				// Removes quotes
				json = json.Remove(0, 1);
				json = json.Remove(json.Length - 1, 1);

				// Creates (meeting information, members, time members will be added) files
				for (int i = 0; i < int.MaxValue; i++)
				{

					if (File.Exists(@"meetingData/meeting_data" + i.ToString() + ".json"))
					{

						continue;
					}

					else
					{

						File.WriteAllText(@"meetingData/meeting_data" + i.ToString() + ".json", json);
						File.WriteAllText(@"memberData/member_data" + i.ToString() + ".json", '"' + login + '"');
						File.WriteAllText(@"dateData/date_data" + i.ToString() + ".json", '"' + meeting_info[5] + '"');
						break;
					}
				}

				// Garbage collector
				GC.Collect();
				GC.WaitForPendingFinalizers();
				
				Console.WriteLine("/            Meeting successfuly created            /");
				Console.WriteLine("/                                                   /");
				Console.WriteLine("/////////////////////////////////////////////////////");
				Console.WriteLine("/                                                   /");
				Console.Write("/ ");
				command = Console.ReadLine();
				break;

			// Deletes files that contains all information about chosen meeting
			case "delete":

				int j = 0;
				bool created = false;
				Console.WriteLine("/                                                   /");
				Console.WriteLine("/              Meetings created by you              /");
				Console.WriteLine("/                                                   /");

				// Shows all meetings created by current logged user
				for (int i = 0; i < int.MaxValue; i++)
				{

					if (File.Exists(@"meetingData/meeting_data" + i.ToString() + ".json"))
					{

						j = 0;
						StreamReader r = new StreamReader(@"meetingData/meeting_data" + i.ToString() + ".json");
						string jsonString = r.ReadLine();
						MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);

						r.Dispose();
						r.Close();
						GC.Collect();
						GC.WaitForPendingFinalizers();

						if (meet_data.Responsible_person == login)
						{

							Console.WriteLine("/ #" + i.ToString());
							Console.WriteLine("/ Name: " + meet_data.Name);
							Console.WriteLine("/ Start date: " + meet_data.Start_date);
							Console.WriteLine("/ End date: " + meet_data.End_date);
							Console.WriteLine("/                                                   /");
							created = true;
						}
					}

					else
					{

						j++;
					}

					// Prints warning that current user has no created meetings
					if (j == 200 && created == false)
					{

						Console.WriteLine("/                                                   /");
						Console.WriteLine("/            You have no created meetings           /");
						Console.WriteLine("/                                                   /");
						Console.WriteLine("/       To delete some you need to create some      /");
						Console.WriteLine("/                                                   /");
						break;
					}

					else if (j == 200)
					{

						break;
					}
				}

				// Breaks further code if no meetings created by current user
				if (j == 200 && created == false)
				{

					Console.WriteLine("/////////////////////////////////////////////////////");
					Console.WriteLine("/                                                   /");
					Console.Write("/ ");
					command = Console.ReadLine();
					break;
				}

				Console.WriteLine("/       Type the number of meeting to delete it     /");
				Console.WriteLine("/               (Type without hashtag)              /");
				Console.WriteLine("/                                                   /");
				Console.Write("/ Number: ");
				string number = Console.ReadLine();

				// Reads number of meeting and deletes it if it's created by current logged user
				if (File.Exists(@"meetingData/meeting_data" + number + ".json") && number != null)
				{

					StreamReader r = new StreamReader(@"meetingData/meeting_data" + number + ".json");
					string jsonString = r.ReadLine();
					MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);

					// Disposing and closing stream to be able to write information to files
					r.Dispose();
					r.Close();
					GC.Collect();
					GC.WaitForPendingFinalizers();

					// Deletes files
					if (meet_data.Responsible_person == login)
					{

						File.Delete(@"dateData/date_data" + number + ".json");
						File.Delete(@"memberData/member_data" + number + ".json");
						File.Delete(@"meetingData/meeting_data" + number + ".json");
						Console.WriteLine("/                                                   /");
						Console.WriteLine("/            Meeting successfuly deleted            /");
						Console.WriteLine("/                                                   /");
					}

					// If current logged user is not a creator of chosen meeting - warning will be shown
					else
					{

						Console.WriteLine("/                                                   /");
						Console.WriteLine("/ You aren't the responsible person of this meeting /");
						Console.WriteLine("/                                                   /");
					}
				}

				else
				{

					Console.WriteLine("/                                                   /");
					Console.WriteLine("/   No such meeting or number given was incorrect   /");
					Console.WriteLine("/                                                   /");
				}
				
				Console.WriteLine("/         Do you want to delete another one?        /");
				Console.WriteLine("/                      (Yes/No)                     /");
				Console.WriteLine("/                                                   /");
				Console.Write("/ ");
				string another = Console.ReadLine();

				// Reads input from user to continue or discontinue deleting files
				if (another == "yes" || another == "Yes" || another == "Y" || another == "y")
				{

					Console.WriteLine("/                                                   /");
					Console.WriteLine("/--------------------           --------------------/");
					Console.WriteLine("/                                                   /");
					break;
				}

				else
				{

					Console.WriteLine("/                                                   /");
					Console.WriteLine("/////////////////////////////////////////////////////");
					Console.WriteLine("/                                                   /");
					Console.Write("/ ");
					command = Console.ReadLine();
					break;
				}

			// Adds members to created by current logged user meetings
			case "add":

				int k = 0;
				bool iscreated = false;
				Console.WriteLine("/                                                   /");
				Console.WriteLine("/              Meetings created by you              /");
				Console.WriteLine("/                                                   /");

				// Shows all meetings created by current logged user
				for (int i = 0; i < int.MaxValue; i++)
				{

					if (File.Exists(@"meetingData/meeting_data" + i.ToString() + ".json"))
					{

						k = 0;
						List<string> tempListMembers = new List<string>();
						List<string> tempListDates = new List<string>();
						StreamReader r = new StreamReader(@"meetingData/meeting_data" + i.ToString() + ".json");
						string jsonString = r.ReadLine();
						MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);
						string srString;
						string[] members = new string[100];
						string srDates;
						string[] dates = new string[100];

						if (File.Exists(@"memberData/member_data" + i.ToString() + ".json"))
						{

							StreamReader sr = new StreamReader(@"memberData/member_data" + i.ToString() + ".json");
							srString = sr.ReadLine();
							StreamReader ssr = new StreamReader(@"dateData/date_data" + i.ToString() + ".json");
							srDates = ssr.ReadLine();

							if (srString != null && srDates != null)
							{

								string[] temp = srString.Split(',');
								string[] temp1 = srDates.Split(',');

								for (int a = 0; a < temp.Length; a++)
								{

									members[a] = temp[a];
									members[a] = members[a].Remove(0, 1);
									members[a] = members[a].Remove(members[a].Length - 1, 1);

									dates[a] = temp1[a];
									dates[a] = dates[a].Remove(0, 1);
									dates[a] = dates[a].Remove(dates[a].Length - 1, 1);
								}
							}

							r.Dispose();
							r.Close();
							sr.Dispose();
							sr.Close();
							ssr.Dispose();
							ssr.Close();
							GC.Collect();
							GC.WaitForPendingFinalizers();

							foreach (string mem in members)
							{

								if (!string.IsNullOrEmpty(mem))
								{

									tempListMembers.Add(mem);
								}
									
							}

							foreach (string dat in dates)
							{

								if (!string.IsNullOrEmpty(dat))
								{

									tempListDates.Add(dat);
								}
									
							}

							members = tempListMembers.ToArray();
							dates = tempListDates.ToArray();
						}

						if (meet_data.Responsible_person == login)
						{

							Console.WriteLine("/ #" + i.ToString());
							Console.WriteLine("/ Name: " + meet_data.Name);
							Console.WriteLine("/ Start date: " + meet_data.Start_date);
							Console.WriteLine("/ End date: " + meet_data.End_date);
							Console.WriteLine("/ Members:                                          /");

							for (int a = 0; a < members.Length; a++)
							{

								Console.WriteLine("/   " + members[a] + "  " + dates[a]);
							}

							Console.WriteLine("/                                                   /");
							iscreated = true;
						}
					}

					else
					{

						k++;
					}

					if (k == 200 && iscreated == false)
					{

						Console.WriteLine("/                                                   /");
						Console.WriteLine("/            You have no created meetings           /");
						Console.WriteLine("/                                                   /");
						Console.WriteLine("/      To add members you need to create meeting    /");
						Console.WriteLine("/                                                   /");
						break;
					}

					else if (k == 200)
					{

						break;
					}
				}

				// Breaks further code if no meetings created by current user
				if (k == 200 && iscreated == false)
				{

					Console.WriteLine("/////////////////////////////////////////////////////");
					Console.WriteLine("/                                                   /");
					Console.Write("/ ");
					command = Console.ReadLine();
					break;
				}

				Console.WriteLine("/  Type the number of meeting to add members to it  /");
				Console.WriteLine("/               (Type without hashtag)              /");
				Console.WriteLine("/                                                   /");
				Console.Write("/ Number: ");
				string nr = Console.ReadLine();

				// Reads number of meeting and adds members to it if it's created by current logged user
				if (File.Exists(@"meetingData/meeting_data" + nr + ".json") && nr != null)
				{

					List<string> tempListMembers = new List<string>();
					List<string> tempListDates = new List<string>();
					StreamReader r = new StreamReader(@"meetingData/meeting_data" + nr + ".json");
					string jsonString = r.ReadLine();
					MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);
					string srString;
					string[] members = new string[100];
					string srDates;
					string[] dates = new string[100];

					// Reads information about already added members and their join date to temporary variables
					if (File.Exists(@"memberData/member_data" + nr + ".json"))
					{

						StreamReader sr = new StreamReader(@"memberData/member_data" + nr + ".json");
						srString = sr.ReadLine();
						StreamReader ssr = new StreamReader(@"dateData/date_data" + nr + ".json");
						srDates = ssr.ReadLine();

						if (srString != null && srDates != null)
						{

							string[] temp = srString.Split(',');
							string[] temp1 = srDates.Split(',');

							for (int i = 0; i < temp.Length; i++)
							{

								members[i] = temp[i];
								members[i] = members[i].Remove(0, 1);
								members[i] = members[i].Remove(members[i].Length - 1, 1);

								dates[i] = temp1[i];
								dates[i] = dates[i].Remove(0, 1);
								dates[i] = dates[i].Remove(dates[i].Length - 1, 1);
							}
						}

						sr.Dispose();
						sr.Close();
						ssr.Dispose();
						ssr.Close();
						GC.Collect();
						GC.WaitForPendingFinalizers();
					}
					
					// If appropriate meeting was found - starts adding process
					if (meet_data.Responsible_person == login)
					{

						Console.WriteLine("/                                                   /");
						Console.WriteLine("/--------------------           --------------------/");
						Console.WriteLine("/                                                   /");
						Console.WriteLine("/    Type exit if you want to stop adding members   /");
						Console.WriteLine("/                                                   /");
						Console.WriteLine("/--------------------           --------------------/");

						while (true)
						{

							bool exists = false;
							Console.WriteLine("/                                                   /");
							Console.WriteLine("/             Type member login to add              /");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
							string member = Console.ReadLine();

							// Looks if a member is already added
							for (int i = 0; i < members.Length; i++)
							{

								if (member == members[i])
								{

									exists = true;
									break;
								}
							}

							// Shows warning if adding member which is already added
							if (exists == true)
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/        You can't add already added member         /");
							}

							// Shows warning if adding empty member
							else if (member == null)
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/            You can't add empty member             /");
							}

							// Exit
							else if (member == "exit" || member == "Exit")
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/--------------------           --------------------/");
								Console.WriteLine("/                                                   /");
								break;
							}

							else
							{

								bool added = false;

								// Seraches for ordered member
								foreach (string memb in logins)
								{

									if (member == memb)
									{

										// If ordered member found - searches a place for him in 'members' variable
										for (int i = 0; i < members.Length; i++)
										{

											if (members[i] != null)
											{

												continue;
											}

											else
											{

												DateTime dateTime = new();
												DateTime begin = new();
												DateTime finish = new();

												// Writes member to 'members' variable
												members[i] = memb;

												// Orders date when the member will be added to meeting
												while (true)
												{

													Console.WriteLine("/                                                   /");
													Console.WriteLine("/      Enter time at which member will be added     /");
													Console.WriteLine("/                                                   /");
													Console.Write("/ ");

													string date = Console.ReadLine();
													var isValidDate = DateTime.TryParse(date, out dateTime);
													var beginDate = DateTime.TryParse(meet_data.Start_date, out begin);
													var finishDate = DateTime.TryParse(meet_data.End_date, out finish);

													// If all input properly - writes adding date to 'dates' variable
													if (isValidDate && beginDate && finishDate && date != null && dateTime > begin && dateTime < finish)
													{

														dates[i] = date;
														break;
													}

													else
													{

														Console.WriteLine("/                 Inappropriate date                /");
													}
												}

												break;
											}
										}

										Console.WriteLine("/                                                   /");
										Console.WriteLine("/                   Member added                    /");
										Console.WriteLine("/                                                   /");
										
										added = true;
										break;
									}
								}

								if (added == false)
								{

									Console.WriteLine("/                                                   /");
									Console.WriteLine("/              There is no such member              /");
								}
							}

						}

						// Deletes null values in 'members'
						foreach (string mem in members)
						{

							if (!string.IsNullOrEmpty(mem))
							{

								tempListMembers.Add(mem);
							}
						}

						// Deletes null values in 'dates'
						foreach (string dat in dates)
						{

							if (!string.IsNullOrEmpty(dat))
							{

								tempListDates.Add(dat);
							}
						}

						// Assigns cleaned from null arrays to old arrays
						members = tempListMembers.ToArray();
						dates = tempListDates.ToArray();

						if (members == null)
						{

							Console.WriteLine("/                                                   /");
							Console.WriteLine("/               No members were added               /");
							Console.WriteLine("/                                                   /");
							Console.WriteLine("/                                                   /");
							Console.WriteLine("/--------------------           --------------------/");
							Console.WriteLine("/                                                   /");
						}

						// Writes information to files
						else
						{

							string mem = System.Text.Json.JsonSerializer.Serialize(members);
							string dat = System.Text.Json.JsonSerializer.Serialize(dates);

							mem = mem.Remove(0, 1);
							mem = mem.Remove(mem.Length - 1, 1);

							dat = dat.Remove(0, 1);
							dat = dat.Remove(dat.Length - 1, 1);

							File.WriteAllText(@"memberData/member_data" + nr + ".json", mem);
							File.WriteAllText(@"dateData/date_data" + nr + ".json", dat);
						}
					}

					else
					{

						Console.WriteLine("/                                                   /");
						Console.WriteLine("/ You aren't the responsible person of this meeting /");
						Console.WriteLine("/                                                   /");
					}

					r.Dispose();
					r.Close();
					GC.Collect();
					GC.WaitForPendingFinalizers();
				}

				else
				{

					Console.WriteLine("/                                                   /");
					Console.WriteLine("/   No such meeting or number given was incorrect   /");
					Console.WriteLine("/                                                   /");
				}

				Console.WriteLine("/         Do you want to add to another one?        /");
				Console.WriteLine("/                      (Yes/No)                     /");
				Console.WriteLine("/                                                   /");
				Console.Write("/ ");
				string again = Console.ReadLine();

				// Reads input from user to continue or discontinue adding members
				if (again == "yes" || again == "Yes" || again == "Y" || again == "y")
				{

					Console.WriteLine("/                                                   /");
					Console.WriteLine("/--------------------           --------------------/");
					Console.WriteLine("/                                                   /");
					break;
				}

				else
				{

					Console.WriteLine("/                                                   /");
					Console.WriteLine("/////////////////////////////////////////////////////");
					Console.WriteLine("/                                                   /");
					Console.Write("/ ");
					command = Console.ReadLine();
					break;
				}

			// Removes members from meetings created by current logged user
			case "remove":

				int x = 0;
				bool isCreated = false;
				Console.WriteLine("/                                                   /");
				Console.WriteLine("/              Meetings created by you              /");
				Console.WriteLine("/                                                   /");

				// Shows all meetings created by current logged user
				for (int i = 0; i < int.MaxValue; i++)
				{

					if (File.Exists(@"meetingData/meeting_data" + i.ToString() + ".json"))
					{

						j = 0;
						List<string> tempListMembers = new List<string>();
						List<string> tempListDates = new List<string>();
						StreamReader r = new StreamReader(@"meetingData/meeting_data" + i.ToString() + ".json");
						string jsonString = r.ReadLine();
						MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);
						string srString;
						string[] members = new string[100];
						string srDates;
						string[] dates = new string[100];

						r.Dispose();
						r.Close();
						GC.Collect();
						GC.WaitForPendingFinalizers();

						if (File.Exists(@"memberData/member_data" + i.ToString() + ".json"))
						{

							StreamReader sr = new StreamReader(@"memberData/member_data" + i.ToString() + ".json");
							srString = sr.ReadLine();
							StreamReader ssr = new StreamReader(@"dateData/date_data" + i.ToString() + ".json");
							srDates = ssr.ReadLine();

							if (srString != null && srDates != null)
							{

								string[] temp = srString.Split(',');
								string[] temp1 = srDates.Split(',');

								for (int a = 0; a < temp.Length; a++)
								{

									members[a] = temp[a];
									members[a] = members[a].Remove(0, 1);
									members[a] = members[a].Remove(members[a].Length - 1, 1);

									dates[a] = temp1[a];
									dates[a] = dates[a].Remove(0, 1);
									dates[a] = dates[a].Remove(dates[a].Length - 1, 1);
								}
							}

							sr.Dispose();
							sr.Close();
							ssr.Dispose();
							ssr.Close();
							GC.Collect();
							GC.WaitForPendingFinalizers();

							foreach (string mem in members)
							{

								if (!string.IsNullOrEmpty(mem))
								{

									tempListMembers.Add(mem);
								}

							}

							foreach (string dat in dates)
							{

								if (!string.IsNullOrEmpty(dat))
								{

									tempListDates.Add(dat);
								}

							}

							members = tempListMembers.ToArray();
							dates = tempListDates.ToArray();
						}

						if (meet_data.Responsible_person == login)
						{

							Console.WriteLine("/ #" + i.ToString());
							Console.WriteLine("/ Name: " + meet_data.Name);
							Console.WriteLine("/ Start date: " + meet_data.Start_date);
							Console.WriteLine("/ End date: " + meet_data.End_date);
							Console.WriteLine("/ Members:                                          /");

							for (int a = 0; a < members.Length; a++)
							{

								Console.WriteLine("/   " + members[a] + "  " + dates[a]);
							}
							Console.WriteLine("/                                                   /");
							isCreated = true;
						}
					}

					else
					{

						x++;
					}

					if (x == 200 && isCreated == false)
					{

						Console.WriteLine("/                                                   /");
						Console.WriteLine("/            You have no created meetings           /");
						Console.WriteLine("/                                                   /");
						Console.WriteLine("/       To delete some you need to create some      /");
						Console.WriteLine("/                                                   /");
						break;
					}

					else if (x == 200)
					{

						break;
					}
				}

				// Breaks further code if no meetings created by current user
				if (x == 200 && isCreated == false)
				{

					Console.WriteLine("/////////////////////////////////////////////////////");
					Console.WriteLine("/                                                   /");
					Console.Write("/ ");
					command = Console.ReadLine();
					break;
				}

				Console.WriteLine("/    Type the number of meeting to remove member    /");
				Console.WriteLine("/               (Type without hashtag)              /");
				Console.WriteLine("/                                                   /");
				Console.Write("/ Number: ");
				string value = Console.ReadLine();

				// Removes members
				if (File.Exists(@"meetingData/meeting_data" + value + ".json") && value != null)
				{

					List<string> tempListMembers = new List<string>();
					List<string> tempListDates = new List<string>();
					StreamReader r = new StreamReader(@"meetingData/meeting_data" + value + ".json");
					string jsonString = r.ReadLine();
					MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);
					string srString;
					string[] members = new string[100];
					string srDates;
					string[] dates = new string[100];

					r.Dispose();
					r.Close();
					GC.Collect();
					GC.WaitForPendingFinalizers();

					if (File.Exists(@"memberData/member_data" + value + ".json"))
					{

						StreamReader sr = new StreamReader(@"memberData/member_data" + value + ".json");
						srString = sr.ReadLine();
						StreamReader ssr = new StreamReader(@"dateData/date_data" + value + ".json");
						srDates = ssr.ReadLine();

						if (srString != null && srDates != null)
						{

							string[] temp = srString.Split(',');
							string[] temp1 = srDates.Split(',');

							for (int i = 0; i < temp.Length; i++)
							{

								members[i] = temp[i];
								members[i] = members[i].Remove(0, 1);
								members[i] = members[i].Remove(members[i].Length - 1, 1);

								dates[i] = temp1[i];
								dates[i] = dates[i].Remove(0, 1);
								dates[i] = dates[i].Remove(dates[i].Length - 1, 1);
							}
						}

						sr.Dispose();
						sr.Close();
						ssr.Dispose();
						ssr.Close();
						GC.Collect();
						GC.WaitForPendingFinalizers();
					}


					if (meet_data.Responsible_person == login)
					{

						Console.WriteLine("/                                                   /");
						Console.WriteLine("/--------------------           --------------------/");
						Console.WriteLine("/                                                   /");
						Console.WriteLine("/   Type exit if you want to stop removing members  /");
						Console.WriteLine("/                                                   /");
						Console.WriteLine("/--------------------           --------------------/");

						while (true)
						{

							bool exists = false;
							Console.WriteLine("/                                                   /");
							Console.WriteLine("/            Type member login to remove            /");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
							string member = Console.ReadLine();

							for (int i = 0; i < members.Length; i++)
							{

								// Shows warning if trying to remove owner of the meeting
								if (member == login && login == members[i])
								{

									Console.WriteLine("/                                                   /");
									Console.WriteLine("/          You can't delete meeting owner           /");

									exists = true;
								}

								// Removes member if found
								else if (member == members[i])
								{

									members[i] = "";
									dates[i] = "";

									Console.WriteLine("/                                                   /");
									Console.WriteLine("/                   Member removed                  /");

									exists = true;
									break;
								}
							}

							if (member == null)
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/           You can't remove empty member           /");
							}

							else if (member == "exit" || member == "Exit")
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/--------------------           --------------------/");
								Console.WriteLine("/                                                   /");
								break;
							}

							else if (exists == false)
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/              There is no such member              /");
							}
						}

						foreach (string mm in members)
						{

							if (!string.IsNullOrEmpty(mm))
							{

								tempListMembers.Add(mm);
							}
						}

						foreach (string dt in dates)
						{

							if (!string.IsNullOrEmpty(dt))
							{

								tempListDates.Add(dt);
							}
						}

						members = tempListMembers.ToArray();
						dates = tempListDates.ToArray();

						string mem = System.Text.Json.JsonSerializer.Serialize(members);
						string dat = System.Text.Json.JsonSerializer.Serialize(dates);

						mem = mem.Remove(0, 1);
						mem = mem.Remove(mem.Length - 1, 1);

						dat = dat.Remove(0, 1);
						dat = dat.Remove(dat.Length - 1, 1);

						// Writes new information to files
						File.WriteAllText(@"memberData/member_data" + value + ".json", mem);
						File.WriteAllText(@"dateData/date_data" + value + ".json", dat);
					}

					else
					{

						Console.WriteLine("/                                                   /");
						Console.WriteLine("/ You aren't the responsible person of this meeting /");
						Console.WriteLine("/                                                   /");
					}
				}

				else
				{

					Console.WriteLine("/                                                   /");
					Console.WriteLine("/   No such meeting or number given was incorrect   /");
					Console.WriteLine("/                                                   /");
				}

				Console.WriteLine("/       Do you want to remove from another one?     /");
				Console.WriteLine("/                      (Yes/No)                     /");
				Console.WriteLine("/                                                   /");
				Console.Write("/ ");
				string Again = Console.ReadLine();

				// Reads input from user to continue or discontinue removing members
				if (Again == "yes" || Again == "Yes" || Again == "Y" || Again == "y")
				{

					Console.WriteLine("/                                                   /");
					Console.WriteLine("/--------------------           --------------------/");
					Console.WriteLine("/                                                   /");
					break;
				}

				else
				{

					Console.WriteLine("/                                                   /");
					Console.WriteLine("/////////////////////////////////////////////////////");
					Console.WriteLine("/                                                   /");
					Console.Write("/ ");
					command = Console.ReadLine();
					break;
				}

			// Shows list of all created meetings
			// Applying filter will show more precise quantity of needed meetings
			case "list":

				int d = 0;
				string filter, filter_val;
				bool exist = false;
				bool loop = true;
				Console.WriteLine("/////////////////////////////////////////////////////");
				Console.WriteLine("/                                                   /");
				Console.WriteLine("/          Type filter for possible filters         /");
				Console.WriteLine("/               Type exit to exit list              /");
				Console.WriteLine("/                                                   /");
				Console.WriteLine("/--------------------           --------------------/");
				Console.WriteLine("/                                                   /");
				Console.WriteLine("/                  List of meetings                 /");
				Console.WriteLine("/                                                   /");
				Console.WriteLine("/--------------------           --------------------/");
				Console.WriteLine("/                                                   /");

				// Shows list of all created meetings
				for (int i = 0; i < int.MaxValue; i++)
				{

					if (File.Exists(@"meetingData/meeting_data" + i.ToString() + ".json"))
					{

						j = 0;
						List<string> tempListMembers = new List<string>();
						List<string> tempListDates = new List<string>();
						StreamReader r = new StreamReader(@"meetingData/meeting_data" + i.ToString() + ".json");
						string jsonString = r.ReadLine();
						MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);
						string srString;
						string[] members = new string[100];
						string srDates;
						string[] dates = new string[100];

						r.Dispose();
						r.Close();
						GC.Collect();
						GC.WaitForPendingFinalizers();

						if (File.Exists(@"memberData/member_data" + i.ToString() + ".json"))
						{

							StreamReader sr = new StreamReader(@"memberData/member_data" + i.ToString() + ".json");
							srString = sr.ReadLine();
							StreamReader ssr = new StreamReader(@"dateData/date_data" + i.ToString() + ".json");
							srDates = ssr.ReadLine();

							if (srString != null && srDates != null)
							{

								string[] temp = srString.Split(',');
								string[] temp1 = srDates.Split(',');

								for (int a = 0; a < temp.Length; a++)
								{

									members[a] = temp[a];
									members[a] = members[a].Remove(0, 1);
									members[a] = members[a].Remove(members[a].Length - 1, 1);

									dates[a] = temp1[a];
									dates[a] = dates[a].Remove(0, 1);
									dates[a] = dates[a].Remove(dates[a].Length - 1, 1);
								}
							}

							sr.Dispose();
							sr.Close();
							ssr.Dispose();
							ssr.Close();
							GC.Collect();
							GC.WaitForPendingFinalizers();

							foreach (string mem in members)
							{

								if (!string.IsNullOrEmpty(mem))
								{

									tempListMembers.Add(mem);
								}

							}

							foreach (string dat in dates)
							{

								if (!string.IsNullOrEmpty(dat))
								{

									tempListDates.Add(dat);
								}

							}

							members = tempListMembers.ToArray();
							dates = tempListDates.ToArray();
						}

						Console.WriteLine("/ #" + i.ToString());
						Console.WriteLine("/ Name: " + meet_data.Name);
						Console.WriteLine("/ Start date: " + meet_data.Start_date);
						Console.WriteLine("/ End date: " + meet_data.End_date);
						Console.WriteLine("/ Members:                                          /");

						for (int a = 0; a < members.Length; a++)
						{

							Console.WriteLine("/   " + members[a] + "  " + dates[a]);
						}

						Console.WriteLine("/                                                   /");
						Console.WriteLine("/--------------------           --------------------/");
						Console.WriteLine("/                                                   /");
						exist = true;
					}

					else
					{

						d++;
					}

					if (d == 200 && exist == false)
					{

						Console.WriteLine("/                                                   /");
						Console.WriteLine("/              No created meetings found            /");
						Console.WriteLine("/                                                   /");
						break;
					}

					else if (d == 200)
					{

						break;
					}
				}

				// Breaks further code if no meetings created
				if (d == 200 && exist == false)
				{

					Console.WriteLine("/////////////////////////////////////////////////////");
					Console.WriteLine("/                                                   /");
					Console.Write("/ ");
					command = Console.ReadLine();
					break;
				}

				Console.Write("/ ");
				filter = Console.ReadLine();

				while (loop == true)
				{

					switch (filter)
					{

						// Shows list of possible filters
						case "filter":

							Console.WriteLine("/                                                   /");
							Console.WriteLine("/--------------------           --------------------/");
							Console.WriteLine("/                                                   /");
							Console.WriteLine("/                  List of filters                  /");
							Console.WriteLine("/                                                   /");
							Console.WriteLine("/--------------------           --------------------/");
							Console.WriteLine("/                                                   /");
							Console.WriteLine("/ description                                       /");
							Console.WriteLine("/ responsible                                       /");
							Console.WriteLine("/ category                                          /");
							Console.WriteLine("/ type                                              /");
							Console.WriteLine("/ date                                              /");
							Console.WriteLine("/ date from                                         /");
							Console.WriteLine("/ date till                                         /");
							Console.WriteLine("/ date between                                      /");
							Console.WriteLine("/ members                                           /");
							Console.WriteLine("/ members over                                      /");
							Console.WriteLine("/ members under                                     /");
							Console.WriteLine("/ members between                                   /");
							Console.WriteLine("/                                                   /");
							Console.WriteLine("/--------------------           --------------------/");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
							filter = Console.ReadLine();
							break;

						// Will filter by ordered description of meeting
						// Finds by full description or keyword
						case "description":

							Console.WriteLine("/                                                   /");
							Console.WriteLine("/--------------------           --------------------/");
							Console.WriteLine("/                                                   /");
							Console.WriteLine("/                 Enter description                 /");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
							filter_val = Console.ReadLine();

							if (filter_val == "exit")
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/---------------------------------------------------/");
								Console.WriteLine("/                                                   /");
								Console.Write("/ ");
								filter = Console.ReadLine();
								break;
							}

							else if (filter_val != null)
                            {

								for (int i = 0; i < int.MaxValue; i++)
								{

									if (File.Exists(@"meetingData/meeting_data" + i.ToString() + ".json"))
									{

										exist = false;
										j = 0;
										List<string> tempListMembers = new List<string>();
										List<string> tempListDates = new List<string>();
										StreamReader r = new StreamReader(@"meetingData/meeting_data" + i.ToString() + ".json");
										string jsonString = r.ReadLine();
										MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);
										string srString;
										string[] members = new string[100];
										string srDates;
										string[] dates = new string[100];

										r.Dispose();
										r.Close();
										GC.Collect();
										GC.WaitForPendingFinalizers();

										if (File.Exists(@"memberData/member_data" + i.ToString() + ".json"))
										{

											StreamReader sr = new StreamReader(@"memberData/member_data" + i.ToString() + ".json");
											srString = sr.ReadLine();
											StreamReader ssr = new StreamReader(@"dateData/date_data" + i.ToString() + ".json");
											srDates = ssr.ReadLine();

											if (srString != null && srDates != null)
											{

												string[] temp = srString.Split(',');
												string[] temp1 = srDates.Split(',');

												for (int a = 0; a < temp.Length; a++)
												{

													members[a] = temp[a];
													members[a] = members[a].Remove(0, 1);
													members[a] = members[a].Remove(members[a].Length - 1, 1);

													dates[a] = temp1[a];
													dates[a] = dates[a].Remove(0, 1);
													dates[a] = dates[a].Remove(dates[a].Length - 1, 1);
												}
											}

											sr.Dispose();
											sr.Close();
											ssr.Dispose();
											ssr.Close();
											GC.Collect();
											GC.WaitForPendingFinalizers();

											foreach (string mem in members)
											{

												if (!string.IsNullOrEmpty(mem))
												{

													tempListMembers.Add(mem);
												}

											}

											foreach (string dat in dates)
											{

												if (!string.IsNullOrEmpty(dat))
												{

													tempListDates.Add(dat);
												}

											}

											members = tempListMembers.ToArray();
											dates = tempListDates.ToArray();
										}

										if (meet_data.Description.Contains(filter_val))
										{

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/ #" + i.ToString());
											Console.WriteLine("/ Name: " + meet_data.Name);
											Console.WriteLine("/ Start date: " + meet_data.Start_date);
											Console.WriteLine("/ End date: " + meet_data.End_date);
											Console.WriteLine("/ Members:                                          /");

											for (int a = 0; a < members.Length; a++)
											{

												Console.WriteLine("/   " + members[a] + "  " + dates[a]);
											}

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/--------------------           --------------------/");
											Console.WriteLine("/                                                   /");
											exist = true;
										}
									}

									else
									{

										d++;
									}

									if (d == 200 && exist == false)
									{

										Console.WriteLine("/                                                   /");
										Console.WriteLine("/               No such meetings found              /");
										Console.WriteLine("/                                                   /");
										break;
									}

									else if (d == 200)
									{

										break;
									}
								}
							}
							
							else
                            {

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/            Inappropriate filter value             /");
								break;
                            }

							break;

						// Will filter by ordered owner of meeting
						case "responsible":

							Console.WriteLine("/                                                   /");
							Console.WriteLine("/--------------------           --------------------/");
							Console.WriteLine("/                                                   /");
							Console.WriteLine("/              Enter responsible person             /");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
							filter_val = Console.ReadLine();

							if (filter_val == "exit")
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/---------------------------------------------------/");
								Console.WriteLine("/                                                   /");
								Console.Write("/ ");
								filter = Console.ReadLine();
								break;
							}

							else if (filter_val != null)
							{

								for (int i = 0; i < int.MaxValue; i++)
								{

									if (File.Exists(@"meetingData/meeting_data" + i.ToString() + ".json"))
									{

										exist = false;
										j = 0;
										List<string> tempListMembers = new List<string>();
										List<string> tempListDates = new List<string>();
										StreamReader r = new StreamReader(@"meetingData/meeting_data" + i.ToString() + ".json");
										string jsonString = r.ReadLine();
										MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);
										string srString;
										string[] members = new string[100];
										string srDates;
										string[] dates = new string[100];

										r.Dispose();
										r.Close();
										GC.Collect();
										GC.WaitForPendingFinalizers();

										if (File.Exists(@"memberData/member_data" + i.ToString() + ".json"))
										{

											StreamReader sr = new StreamReader(@"memberData/member_data" + i.ToString() + ".json");
											srString = sr.ReadLine();
											StreamReader ssr = new StreamReader(@"dateData/date_data" + i.ToString() + ".json");
											srDates = ssr.ReadLine();

											if (srString != null && srDates != null)
											{

												string[] temp = srString.Split(',');
												string[] temp1 = srDates.Split(',');

												for (int a = 0; a < temp.Length; a++)
												{

													members[a] = temp[a];
													members[a] = members[a].Remove(0, 1);
													members[a] = members[a].Remove(members[a].Length - 1, 1);

													dates[a] = temp1[a];
													dates[a] = dates[a].Remove(0, 1);
													dates[a] = dates[a].Remove(dates[a].Length - 1, 1);
												}
											}

											sr.Dispose();
											sr.Close();
											ssr.Dispose();
											ssr.Close();
											GC.Collect();
											GC.WaitForPendingFinalizers();

											foreach (string mem in members)
											{

												if (!string.IsNullOrEmpty(mem))
												{

													tempListMembers.Add(mem);
												}

											}

											foreach (string dat in dates)
											{

												if (!string.IsNullOrEmpty(dat))
												{

													tempListDates.Add(dat);
												}

											}

											members = tempListMembers.ToArray();
											dates = tempListDates.ToArray();
										}

										if (meet_data.Responsible_person.Equals(filter_val))
										{

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/ #" + i.ToString());
											Console.WriteLine("/ Name: " + meet_data.Name);
											Console.WriteLine("/ Start date: " + meet_data.Start_date);
											Console.WriteLine("/ End date: " + meet_data.End_date);
											Console.WriteLine("/ Members:                                          /");

											for (int a = 0; a < members.Length; a++)
											{

												Console.WriteLine("/   " + members[a] + "  " + dates[a]);
											}

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/--------------------           --------------------/");
											Console.WriteLine("/                                                   /");
											exist = true;
										}
									}

									else
									{

										d++;
									}

									if (d == 200 && exist == false)
									{

										Console.WriteLine("/                                                   /");
										Console.WriteLine("/               No such meetings found              /");
										Console.WriteLine("/                                                   /");
										break;
									}

									else if (d == 200)
									{

										break;
									}
								}
							}

							else
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/            Inappropriate filter value             /");
								break;
							}

							break;

						// Will filter by ordered category of meeting
						case "category":

							Console.WriteLine("/                                                   /");
							Console.WriteLine("/--------------------           --------------------/");
							Console.WriteLine("/                                                   /");
							Console.WriteLine("/                   Enter category                  /");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
							filter_val = Console.ReadLine();

							if (filter_val == "exit")
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/---------------------------------------------------/");
								Console.WriteLine("/                                                   /");
								Console.Write("/ ");
								filter = Console.ReadLine();
								break;
							}

							else if (filter_val != null)
							{

								for (int i = 0; i < int.MaxValue; i++)
								{

									if (File.Exists(@"meetingData/meeting_data" + i.ToString() + ".json"))
									{

										exist = false;
										j = 0;
										List<string> tempListMembers = new List<string>();
										List<string> tempListDates = new List<string>();
										StreamReader r = new StreamReader(@"meetingData/meeting_data" + i.ToString() + ".json");
										string jsonString = r.ReadLine();
										MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);
										string srString;
										string[] members = new string[100];
										string srDates;
										string[] dates = new string[100];

										r.Dispose();
										r.Close();
										GC.Collect();
										GC.WaitForPendingFinalizers();

										if (File.Exists(@"memberData/member_data" + i.ToString() + ".json"))
										{

											StreamReader sr = new StreamReader(@"memberData/member_data" + i.ToString() + ".json");
											srString = sr.ReadLine();
											StreamReader ssr = new StreamReader(@"dateData/date_data" + i.ToString() + ".json");
											srDates = ssr.ReadLine();

											if (srString != null && srDates != null)
											{

												string[] temp = srString.Split(',');
												string[] temp1 = srDates.Split(',');

												for (int a = 0; a < temp.Length; a++)
												{

													members[a] = temp[a];
													members[a] = members[a].Remove(0, 1);
													members[a] = members[a].Remove(members[a].Length - 1, 1);

													dates[a] = temp1[a];
													dates[a] = dates[a].Remove(0, 1);
													dates[a] = dates[a].Remove(dates[a].Length - 1, 1);
												}
											}

											sr.Dispose();
											sr.Close();
											ssr.Dispose();
											ssr.Close();
											GC.Collect();
											GC.WaitForPendingFinalizers();

											foreach (string mem in members)
											{

												if (!string.IsNullOrEmpty(mem))
												{

													tempListMembers.Add(mem);
												}

											}

											foreach (string dat in dates)
											{

												if (!string.IsNullOrEmpty(dat))
												{

													tempListDates.Add(dat);
												}

											}

											members = tempListMembers.ToArray();
											dates = tempListDates.ToArray();
										}

										if (meet_data.Category.Equals(filter_val))
										{

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/ #" + i.ToString());
											Console.WriteLine("/ Name: " + meet_data.Name);
											Console.WriteLine("/ Start date: " + meet_data.Start_date);
											Console.WriteLine("/ End date: " + meet_data.End_date);
											Console.WriteLine("/ Members:                                          /");

											for (int a = 0; a < members.Length; a++)
											{

												Console.WriteLine("/   " + members[a] + "  " + dates[a]);
											}

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/--------------------           --------------------/");
											Console.WriteLine("/                                                   /");
											exist = true;
										}
									}

									else
									{

										d++;
									}

									if (d == 200 && exist == false)
									{

										Console.WriteLine("/                                                   /");
										Console.WriteLine("/               No such meetings found              /");
										Console.WriteLine("/                                                   /");
										break;
									}

									else if (d == 200)
									{

										break;
									}
								}
							}

							else
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/            Inappropriate filter value             /");
								break;
							}

							break;

						// Will filter by ordered type of meeting
						case "type":

							Console.WriteLine("/                                                   /");
							Console.WriteLine("/--------------------           --------------------/");
							Console.WriteLine("/                                                   /");
							Console.WriteLine("/                     Enter type                    /");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
							filter_val = Console.ReadLine();

							if (filter_val == "exit")
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/---------------------------------------------------/");
								Console.WriteLine("/                                                   /");
								Console.Write("/ ");
								filter = Console.ReadLine();
								break;
							}

							else if (filter_val != null)
							{

								for (int i = 0; i < int.MaxValue; i++)
								{

									if (File.Exists(@"meetingData/meeting_data" + i.ToString() + ".json"))
									{

										exist = false;
										j = 0;
										List<string> tempListMembers = new List<string>();
										List<string> tempListDates = new List<string>();
										StreamReader r = new StreamReader(@"meetingData/meeting_data" + i.ToString() + ".json");
										string jsonString = r.ReadLine();
										MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);
										string srString;
										string[] members = new string[100];
										string srDates;
										string[] dates = new string[100];

										r.Dispose();
										r.Close();
										GC.Collect();
										GC.WaitForPendingFinalizers();

										if (File.Exists(@"memberData/member_data" + i.ToString() + ".json"))
										{

											StreamReader sr = new StreamReader(@"memberData/member_data" + i.ToString() + ".json");
											srString = sr.ReadLine();
											StreamReader ssr = new StreamReader(@"dateData/date_data" + i.ToString() + ".json");
											srDates = ssr.ReadLine();

											if (srString != null && srDates != null)
											{

												string[] temp = srString.Split(',');
												string[] temp1 = srDates.Split(',');

												for (int a = 0; a < temp.Length; a++)
												{

													members[a] = temp[a];
													members[a] = members[a].Remove(0, 1);
													members[a] = members[a].Remove(members[a].Length - 1, 1);

													dates[a] = temp1[a];
													dates[a] = dates[a].Remove(0, 1);
													dates[a] = dates[a].Remove(dates[a].Length - 1, 1);
												}
											}

											sr.Dispose();
											sr.Close();
											ssr.Dispose();
											ssr.Close();
											GC.Collect();
											GC.WaitForPendingFinalizers();

											foreach (string mem in members)
											{

												if (!string.IsNullOrEmpty(mem))
												{

													tempListMembers.Add(mem);
												}

											}

											foreach (string dat in dates)
											{

												if (!string.IsNullOrEmpty(dat))
												{

													tempListDates.Add(dat);
												}

											}

											members = tempListMembers.ToArray();
											dates = tempListDates.ToArray();
										}

										if (meet_data.Type.Equals(filter_val))
										{

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/ #" + i.ToString());
											Console.WriteLine("/ Name: " + meet_data.Name);
											Console.WriteLine("/ Start date: " + meet_data.Start_date);
											Console.WriteLine("/ End date: " + meet_data.End_date);
											Console.WriteLine("/ Members:                                          /");

											for (int a = 0; a < members.Length; a++)
											{

												Console.WriteLine("/   " + members[a] + "  " + dates[a]);
											}

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/--------------------           --------------------/");
											Console.WriteLine("/                                                   /");
											exist = true;
										}
									}

									else
									{

										d++;
									}

									if (d == 200 && exist == false)
									{

										Console.WriteLine("/                                                   /");
										Console.WriteLine("/               No such meetings found              /");
										Console.WriteLine("/                                                   /");
										break;
									}

									else if (d == 200)
									{

										break;
									}
								}
							}

							else
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/            Inappropriate filter value             /");
								break;
							}

							break;

						// Will filter by exact start date of meeting
						case "date":

                            Console.WriteLine("/                                                   /");
                            Console.WriteLine("/--------------------           --------------------/");
                            Console.WriteLine("/                                                   /");
							Console.WriteLine("/               Enter exact start date              /");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
                            filter_val = Console.ReadLine();

							if (filter_val == "exit")
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/---------------------------------------------------/");
								Console.WriteLine("/                                                   /");
								Console.Write("/ ");
								filter = Console.ReadLine();
								break;
							}

							else if (filter_val != null)
							{

								for (int i = 0; i < int.MaxValue; i++)
								{

									if (File.Exists(@"meetingData/meeting_data" + i.ToString() + ".json"))
									{

										exist = false;
										j = 0;
										List<string> tempListMembers = new List<string>();
										List<string> tempListDates = new List<string>();
										StreamReader r = new StreamReader(@"meetingData/meeting_data" + i.ToString() + ".json");
										string jsonString = r.ReadLine();
										MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);
										string srString;
										string[] members = new string[100];
										string srDates;
										string[] dates = new string[100];

										r.Dispose();
										r.Close();
										GC.Collect();
										GC.WaitForPendingFinalizers();

										if (File.Exists(@"memberData/member_data" + i.ToString() + ".json"))
										{

											StreamReader sr = new StreamReader(@"memberData/member_data" + i.ToString() + ".json");
											srString = sr.ReadLine();
											StreamReader ssr = new StreamReader(@"dateData/date_data" + i.ToString() + ".json");
											srDates = ssr.ReadLine();

											if (srString != null && srDates != null)
											{

												string[] temp = srString.Split(',');
												string[] temp1 = srDates.Split(',');

												for (int a = 0; a < temp.Length; a++)
												{

													members[a] = temp[a];
													members[a] = members[a].Remove(0, 1);
													members[a] = members[a].Remove(members[a].Length - 1, 1);

													dates[a] = temp1[a];
													dates[a] = dates[a].Remove(0, 1);
													dates[a] = dates[a].Remove(dates[a].Length - 1, 1);
												}
											}

											sr.Dispose();
											sr.Close();
											ssr.Dispose();
											ssr.Close();
											GC.Collect();
											GC.WaitForPendingFinalizers();

											foreach (string mem in members)
											{

												if (!string.IsNullOrEmpty(mem))
												{

													tempListMembers.Add(mem);
												}

											}

											foreach (string dat in dates)
											{

												if (!string.IsNullOrEmpty(dat))
												{

													tempListDates.Add(dat);
												}

											}

											members = tempListMembers.ToArray();
											dates = tempListDates.ToArray();
										}

										if (meet_data.Start_date.Equals(filter_val))
										{

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/ #" + i.ToString());
											Console.WriteLine("/ Name: " + meet_data.Name);
											Console.WriteLine("/ Start date: " + meet_data.Start_date);
											Console.WriteLine("/ End date: " + meet_data.End_date);
											Console.WriteLine("/ Members:                                          /");

											for (int a = 0; a < members.Length; a++)
											{

												Console.WriteLine("/   " + members[a] + "  " + dates[a]);
											}

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/--------------------           --------------------/");
											Console.WriteLine("/                                                   /");
											exist = true;
										}
									}

									else
									{

										d++;
									}

									if (d == 200 && exist == false)
									{

										Console.WriteLine("/                                                   /");
										Console.WriteLine("/               No such meetings found              /");
										Console.WriteLine("/                                                   /");
										break;
									}

									else if (d == 200)
									{

										break;
									}
								}
							}

							else
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/            Inappropriate filter value             /");
								break;
							}

							break;

						// Will filter from ordered start date
						case "date from":

                            Console.WriteLine("/                                                   /");
                            Console.WriteLine("/--------------------           --------------------/");
                            Console.WriteLine("/                                                   /");
							Console.WriteLine("/                  Enter 'from' date                /");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
                            filter_val = Console.ReadLine();

							if (filter_val == "exit")
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/---------------------------------------------------/");
								Console.WriteLine("/                                                   /");
								Console.Write("/ ");
								filter = Console.ReadLine();
								break;
							}

							else if (filter_val != null)
							{

								DateTime date = new();
								DateTime date1 = new();

								for (int i = 0; i < int.MaxValue; i++)
								{

									if (File.Exists(@"meetingData/meeting_data" + i.ToString() + ".json"))
									{

										exist = false;
										j = 0;
										List<string> tempListMembers = new List<string>();
										List<string> tempListDates = new List<string>();
										StreamReader r = new StreamReader(@"meetingData/meeting_data" + i.ToString() + ".json");
										string jsonString = r.ReadLine();
										MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);
										string srString;
										string[] members = new string[100];
										string srDates;
										string[] dates = new string[100];

										r.Dispose();
										r.Close();
										GC.Collect();
										GC.WaitForPendingFinalizers();

										if (File.Exists(@"memberData/member_data" + i.ToString() + ".json"))
										{

											StreamReader sr = new StreamReader(@"memberData/member_data" + i.ToString() + ".json");
											srString = sr.ReadLine();
											StreamReader ssr = new StreamReader(@"dateData/date_data" + i.ToString() + ".json");
											srDates = ssr.ReadLine();

											if (srString != null && srDates != null)
											{

												string[] temp = srString.Split(',');
												string[] temp1 = srDates.Split(',');

												for (int a = 0; a < temp.Length; a++)
												{

													members[a] = temp[a];
													members[a] = members[a].Remove(0, 1);
													members[a] = members[a].Remove(members[a].Length - 1, 1);

													dates[a] = temp1[a];
													dates[a] = dates[a].Remove(0, 1);
													dates[a] = dates[a].Remove(dates[a].Length - 1, 1);
												}
											}

											sr.Dispose();
											sr.Close();
											ssr.Dispose();
											ssr.Close();
											GC.Collect();
											GC.WaitForPendingFinalizers();

											foreach (string mem in members)
											{

												if (!string.IsNullOrEmpty(mem))
												{

													tempListMembers.Add(mem);
												}

											}

											foreach (string dat in dates)
											{

												if (!string.IsNullOrEmpty(dat))
												{

													tempListDates.Add(dat);
												}

											}

											members = tempListMembers.ToArray();
											dates = tempListDates.ToArray();
										}

										var isValidDate = DateTime.TryParse(filter_val, out date);
										var beginDate = DateTime.TryParse(meet_data.Start_date, out date1);

										if (isValidDate && beginDate && date1 >= date)
										{

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/ #" + i.ToString());
											Console.WriteLine("/ Name: " + meet_data.Name);
											Console.WriteLine("/ Start date: " + meet_data.Start_date);
											Console.WriteLine("/ End date: " + meet_data.End_date);
											Console.WriteLine("/ Members:                                          /");

											for (int a = 0; a < members.Length; a++)
											{

												Console.WriteLine("/   " + members[a] + "  " + dates[a]);
											}

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/--------------------           --------------------/");
											Console.WriteLine("/                                                   /");
											exist = true;
										}
									}

									else
									{

										d++;
									}

									if (d == 200 && exist == false)
									{

										Console.WriteLine("/                                                   /");
										Console.WriteLine("/               No such meetings found              /");
										Console.WriteLine("/                                                   /");
										break;
									}

									else if (d == 200)
									{

										break;
									}
								}
							}

							else
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/            Inappropriate filter value             /");
								break;
							}

							break;

						// Will filter to ordered start date
						case "date till":

							Console.WriteLine("/                                                   /");
                            Console.WriteLine("/--------------------           --------------------/");
                            Console.WriteLine("/                                                   /");
							Console.WriteLine("/                   Enter 'to' date                 /");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
                            filter_val = Console.ReadLine();

							if (filter_val == "exit")
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/---------------------------------------------------/");
								Console.WriteLine("/                                                   /");
								Console.Write("/ ");
								filter = Console.ReadLine();
								break;
							}

							else if (filter_val != null)
							{

								DateTime date = new();
								DateTime date1 = new();

								for (int i = 0; i < int.MaxValue; i++)
								{

									if (File.Exists(@"meetingData/meeting_data" + i.ToString() + ".json"))
									{

										exist = false;
										j = 0;
										List<string> tempListMembers = new List<string>();
										List<string> tempListDates = new List<string>();
										StreamReader r = new StreamReader(@"meetingData/meeting_data" + i.ToString() + ".json");
										string jsonString = r.ReadLine();
										MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);
										string srString;
										string[] members = new string[100];
										string srDates;
										string[] dates = new string[100];

										r.Dispose();
										r.Close();
										GC.Collect();
										GC.WaitForPendingFinalizers();

										if (File.Exists(@"memberData/member_data" + i.ToString() + ".json"))
										{

											StreamReader sr = new StreamReader(@"memberData/member_data" + i.ToString() + ".json");
											srString = sr.ReadLine();
											StreamReader ssr = new StreamReader(@"dateData/date_data" + i.ToString() + ".json");
											srDates = ssr.ReadLine();

											if (srString != null && srDates != null)
											{

												string[] temp = srString.Split(',');
												string[] temp1 = srDates.Split(',');

												for (int a = 0; a < temp.Length; a++)
												{

													members[a] = temp[a];
													members[a] = members[a].Remove(0, 1);
													members[a] = members[a].Remove(members[a].Length - 1, 1);

													dates[a] = temp1[a];
													dates[a] = dates[a].Remove(0, 1);
													dates[a] = dates[a].Remove(dates[a].Length - 1, 1);
												}
											}

											sr.Dispose();
											sr.Close();
											ssr.Dispose();
											ssr.Close();
											GC.Collect();
											GC.WaitForPendingFinalizers();

											foreach (string mem in members)
											{

												if (!string.IsNullOrEmpty(mem))
												{

													tempListMembers.Add(mem);
												}

											}

											foreach (string dat in dates)
											{

												if (!string.IsNullOrEmpty(dat))
												{

													tempListDates.Add(dat);
												}

											}

											members = tempListMembers.ToArray();
											dates = tempListDates.ToArray();
										}

										var isValidDate = DateTime.TryParse(filter_val, out date);
										var beginDate = DateTime.TryParse(meet_data.Start_date, out date1);

										if (isValidDate && beginDate && date1 <= date)
										{

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/ #" + i.ToString());
											Console.WriteLine("/ Name: " + meet_data.Name);
											Console.WriteLine("/ Start date: " + meet_data.Start_date);
											Console.WriteLine("/ End date: " + meet_data.End_date);
											Console.WriteLine("/ Members:                                          /");

											for (int a = 0; a < members.Length; a++)
											{

												Console.WriteLine("/   " + members[a] + "  " + dates[a]);
											}

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/--------------------           --------------------/");
											Console.WriteLine("/                                                   /");
											exist = true;
										}
									}

									else
									{

										d++;
									}

									if (d == 200 && exist == false)
									{

										Console.WriteLine("/                                                   /");
										Console.WriteLine("/               No such meetings found              /");
										Console.WriteLine("/                                                   /");
										break;
									}

									else if (d == 200)
									{

										break;
									}
								}
							}

							else
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/            Inappropriate filter value             /");
								break;
							}

							break;

						// Will filter by date between ordered 'from' and 'to' dates
						case "date between":

                            Console.WriteLine("/                                                   /");
                            Console.WriteLine("/--------------------           --------------------/");
                            Console.WriteLine("/                                                   /");
							Console.WriteLine("/                  Enter 'from' date                /");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
                            filter_val = Console.ReadLine();

							if (filter_val == "exit")
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/---------------------------------------------------/");
								Console.WriteLine("/                                                   /");
								Console.Write("/ ");
								filter = Console.ReadLine();
								break;
							}

							Console.WriteLine("/                                                   /");
							Console.WriteLine("/                   Enter 'to' date                 /");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
							string filter_val2 = Console.ReadLine();

							if (filter_val != null)
							{

								DateTime date = new();
								DateTime date1 = new();
								DateTime date2 = new();

								for (int i = 0; i < int.MaxValue; i++)
								{

									if (File.Exists(@"meetingData/meeting_data" + i.ToString() + ".json"))
									{

										exist = false;
										j = 0;
										List<string> tempListMembers = new List<string>();
										List<string> tempListDates = new List<string>();
										StreamReader r = new StreamReader(@"meetingData/meeting_data" + i.ToString() + ".json");
										string jsonString = r.ReadLine();
										MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);
										string srString;
										string[] members = new string[100];
										string srDates;
										string[] dates = new string[100];

										r.Dispose();
										r.Close();
										GC.Collect();
										GC.WaitForPendingFinalizers();

										if (File.Exists(@"memberData/member_data" + i.ToString() + ".json"))
										{

											StreamReader sr = new StreamReader(@"memberData/member_data" + i.ToString() + ".json");
											srString = sr.ReadLine();
											StreamReader ssr = new StreamReader(@"dateData/date_data" + i.ToString() + ".json");
											srDates = ssr.ReadLine();

											if (srString != null && srDates != null)
											{

												string[] temp = srString.Split(',');
												string[] temp1 = srDates.Split(',');

												for (int a = 0; a < temp.Length; a++)
												{

													members[a] = temp[a];
													members[a] = members[a].Remove(0, 1);
													members[a] = members[a].Remove(members[a].Length - 1, 1);

													dates[a] = temp1[a];
													dates[a] = dates[a].Remove(0, 1);
													dates[a] = dates[a].Remove(dates[a].Length - 1, 1);
												}
											}

											sr.Dispose();
											sr.Close();
											ssr.Dispose();
											ssr.Close();
											GC.Collect();
											GC.WaitForPendingFinalizers();

											foreach (string mem in members)
											{

												if (!string.IsNullOrEmpty(mem))
												{

													tempListMembers.Add(mem);
												}

											}

											foreach (string dat in dates)
											{

												if (!string.IsNullOrEmpty(dat))
												{

													tempListDates.Add(dat);
												}

											}

											members = tempListMembers.ToArray();
											dates = tempListDates.ToArray();
										}

										var isValidDate = DateTime.TryParse(filter_val, out date);
										var beginDate = DateTime.TryParse(meet_data.Start_date, out date1);
										var finishDate = DateTime.TryParse(filter_val2, out date2);

										if (isValidDate && beginDate && date1 >= date && date1 <= date2)
										{

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/ #" + i.ToString());
											Console.WriteLine("/ Name: " + meet_data.Name);
											Console.WriteLine("/ Start date: " + meet_data.Start_date);
											Console.WriteLine("/ End date: " + meet_data.End_date);
											Console.WriteLine("/ Members:                                          /");

											for (int a = 0; a < members.Length; a++)
											{

												Console.WriteLine("/   " + members[a] + "  " + dates[a]);
											}

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/--------------------           --------------------/");
											Console.WriteLine("/                                                   /");
											exist = true;
										}
									}

									else
									{

										d++;
									}

									if (d == 200 && exist == false)
									{

										Console.WriteLine("/                                                   /");
										Console.WriteLine("/               No such meetings found              /");
										Console.WriteLine("/                                                   /");
										break;
									}

									else if (d == 200)
									{

										break;
									}
								}
							}

							else
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/            Inappropriate filter value             /");
								break;
							}

							break;

						// Will filter by exact number of members in meeting
						case "members":

                            Console.WriteLine("/                                                   /");
                            Console.WriteLine("/--------------------           --------------------/");
                            Console.WriteLine("/                                                   /");
							Console.WriteLine("/           Enter exact number of members           /");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
                            filter_val = Console.ReadLine();
							int tempVal;

							if (filter_val == "exit")
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/---------------------------------------------------/");
								Console.WriteLine("/                                                   /");
								Console.Write("/ ");
								filter = Console.ReadLine();
								break;
							}

							else if (filter_val != null && int.TryParse(filter_val, out tempVal))
							{

								for (int i = 0; i < int.MaxValue; i++)
								{

									if (File.Exists(@"meetingData/meeting_data" + i.ToString() + ".json"))
									{

										exist = false;
										j = 0;
										List<string> tempListMembers = new List<string>();
										List<string> tempListDates = new List<string>();
										StreamReader r = new StreamReader(@"meetingData/meeting_data" + i.ToString() + ".json");
										string jsonString = r.ReadLine();
										MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);
										string srString;
										string[] members = new string[100];
										string srDates;
										string[] dates = new string[100];

										r.Dispose();
										r.Close();
										GC.Collect();
										GC.WaitForPendingFinalizers();

										if (File.Exists(@"memberData/member_data" + i.ToString() + ".json"))
										{

											StreamReader sr = new StreamReader(@"memberData/member_data" + i.ToString() + ".json");
											srString = sr.ReadLine();
											StreamReader ssr = new StreamReader(@"dateData/date_data" + i.ToString() + ".json");
											srDates = ssr.ReadLine();

											if (srString != null && srDates != null)
											{

												string[] temp = srString.Split(',');
												string[] temp1 = srDates.Split(',');

												for (int a = 0; a < temp.Length; a++)
												{

													members[a] = temp[a];
													members[a] = members[a].Remove(0, 1);
													members[a] = members[a].Remove(members[a].Length - 1, 1);

													dates[a] = temp1[a];
													dates[a] = dates[a].Remove(0, 1);
													dates[a] = dates[a].Remove(dates[a].Length - 1, 1);
												}
											}

											sr.Dispose();
											sr.Close();
											ssr.Dispose();
											ssr.Close();
											GC.Collect();
											GC.WaitForPendingFinalizers();

											foreach (string mem in members)
											{

												if (!string.IsNullOrEmpty(mem))
												{

													tempListMembers.Add(mem);
												}

											}

											foreach (string dat in dates)
											{

												if (!string.IsNullOrEmpty(dat))
												{

													tempListDates.Add(dat);
												}

											}

											members = tempListMembers.ToArray();
											dates = tempListDates.ToArray();
										}

										if (members.Length == tempVal)
										{

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/ #" + i.ToString());
											Console.WriteLine("/ Name: " + meet_data.Name);
											Console.WriteLine("/ Start date: " + meet_data.Start_date);
											Console.WriteLine("/ End date: " + meet_data.End_date);
											Console.WriteLine("/ Members:                                          /");

											for (int a = 0; a < members.Length; a++)
											{

												Console.WriteLine("/   " + members[a] + "  " + dates[a]);
											}

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/--------------------           --------------------/");
											Console.WriteLine("/                                                   /");
											exist = true;
										}
									}

									else
									{

										d++;
									}

									if (d == 200 && exist == false)
									{

										Console.WriteLine("/                                                   /");
										Console.WriteLine("/               No such meetings found              /");
										Console.WriteLine("/                                                   /");
										break;
									}

									else if (d == 200)
									{

										break;
									}
								}
							}

							else
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/            Inappropriate filter value             /");
								break;
							}

							break;

						// Will filter from ordered number of members in meeting
						case "members over":

                            Console.WriteLine("/                                                   /");
                            Console.WriteLine("/--------------------           --------------------/");
                            Console.WriteLine("/                                                   /");
							Console.WriteLine("/                Enter 'from' members               /");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
                            filter_val = Console.ReadLine();
							int tempVal1;

							if (filter_val == "exit")
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/---------------------------------------------------/");
								Console.WriteLine("/                                                   /");
								Console.Write("/ ");
								filter = Console.ReadLine();
								break;
							}

							else if (filter_val != null && int.TryParse(filter_val, out tempVal1))
							{

								for (int i = 0; i < int.MaxValue; i++)
								{

									if (File.Exists(@"meetingData/meeting_data" + i.ToString() + ".json"))
									{

										exist = false;
										j = 0;
										List<string> tempListMembers = new List<string>();
										List<string> tempListDates = new List<string>();
										StreamReader r = new StreamReader(@"meetingData/meeting_data" + i.ToString() + ".json");
										string jsonString = r.ReadLine();
										MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);
										string srString;
										string[] members = new string[100];
										string srDates;
										string[] dates = new string[100];

										r.Dispose();
										r.Close();
										GC.Collect();
										GC.WaitForPendingFinalizers();

										if (File.Exists(@"memberData/member_data" + i.ToString() + ".json"))
										{

											StreamReader sr = new StreamReader(@"memberData/member_data" + i.ToString() + ".json");
											srString = sr.ReadLine();
											StreamReader ssr = new StreamReader(@"dateData/date_data" + i.ToString() + ".json");
											srDates = ssr.ReadLine();

											if (srString != null && srDates != null)
											{

												string[] temp = srString.Split(',');
												string[] temp1 = srDates.Split(',');

												for (int a = 0; a < temp.Length; a++)
												{

													members[a] = temp[a];
													members[a] = members[a].Remove(0, 1);
													members[a] = members[a].Remove(members[a].Length - 1, 1);

													dates[a] = temp1[a];
													dates[a] = dates[a].Remove(0, 1);
													dates[a] = dates[a].Remove(dates[a].Length - 1, 1);
												}
											}

											sr.Dispose();
											sr.Close();
											ssr.Dispose();
											ssr.Close();
											GC.Collect();
											GC.WaitForPendingFinalizers();

											foreach (string mem in members)
											{

												if (!string.IsNullOrEmpty(mem))
												{

													tempListMembers.Add(mem);
												}

											}

											foreach (string dat in dates)
											{

												if (!string.IsNullOrEmpty(dat))
												{

													tempListDates.Add(dat);
												}

											}

											members = tempListMembers.ToArray();
											dates = tempListDates.ToArray();
										}

										if (members.Length >= tempVal1)
										{

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/ #" + i.ToString());
											Console.WriteLine("/ Name: " + meet_data.Name);
											Console.WriteLine("/ Start date: " + meet_data.Start_date);
											Console.WriteLine("/ End date: " + meet_data.End_date);
											Console.WriteLine("/ Members:                                          /");

											for (int a = 0; a < members.Length; a++)
											{

												Console.WriteLine("/   " + members[a] + "  " + dates[a]);
											}

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/--------------------           --------------------/");
											Console.WriteLine("/                                                   /");
											exist = true;
										}
									}

									else
									{

										d++;
									}

									if (d == 200 && exist == false)
									{

										Console.WriteLine("/                                                   /");
										Console.WriteLine("/               No such meetings found              /");
										Console.WriteLine("/                                                   /");
										break;
									}

									else if (d == 200)
									{

										break;
									}
								}
							}

							else
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/            Inappropriate filter value             /");
								break;
							}

							break;

						// Will filter to ordered number of members in meeting
						case "members under":

                            Console.WriteLine("/                                                   /");
                            Console.WriteLine("/--------------------           --------------------/");
                            Console.WriteLine("/                                                   /");
							Console.WriteLine("/                 Enter 'to' members                /");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
                            filter_val = Console.ReadLine();
							int tempVal2;

							if (filter_val == "exit")
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/---------------------------------------------------/");
								Console.WriteLine("/                                                   /");
								Console.Write("/ ");
								filter = Console.ReadLine();
								break;
							}

							else if (filter_val != null && int.TryParse(filter_val, out tempVal2))
							{

								for (int i = 0; i < int.MaxValue; i++)
								{

									if (File.Exists(@"meetingData/meeting_data" + i.ToString() + ".json"))
									{

										exist = false;
										j = 0;
										List<string> tempListMembers = new List<string>();
										List<string> tempListDates = new List<string>();
										StreamReader r = new StreamReader(@"meetingData/meeting_data" + i.ToString() + ".json");
										string jsonString = r.ReadLine();
										MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);
										string srString;
										string[] members = new string[100];
										string srDates;
										string[] dates = new string[100];

										r.Dispose();
										r.Close();
										GC.Collect();
										GC.WaitForPendingFinalizers();

										if (File.Exists(@"memberData/member_data" + i.ToString() + ".json"))
										{

											StreamReader sr = new StreamReader(@"memberData/member_data" + i.ToString() + ".json");
											srString = sr.ReadLine();
											StreamReader ssr = new StreamReader(@"dateData/date_data" + i.ToString() + ".json");
											srDates = ssr.ReadLine();

											if (srString != null && srDates != null)
											{

												string[] temp = srString.Split(',');
												string[] temp1 = srDates.Split(',');

												for (int a = 0; a < temp.Length; a++)
												{

													members[a] = temp[a];
													members[a] = members[a].Remove(0, 1);
													members[a] = members[a].Remove(members[a].Length - 1, 1);

													dates[a] = temp1[a];
													dates[a] = dates[a].Remove(0, 1);
													dates[a] = dates[a].Remove(dates[a].Length - 1, 1);
												}
											}

											sr.Dispose();
											sr.Close();
											ssr.Dispose();
											ssr.Close();
											GC.Collect();
											GC.WaitForPendingFinalizers();

											foreach (string mem in members)
											{

												if (!string.IsNullOrEmpty(mem))
												{

													tempListMembers.Add(mem);
												}

											}

											foreach (string dat in dates)
											{

												if (!string.IsNullOrEmpty(dat))
												{

													tempListDates.Add(dat);
												}

											}

											members = tempListMembers.ToArray();
											dates = tempListDates.ToArray();
										}

										if (members.Length <= tempVal2)
										{

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/ #" + i.ToString());
											Console.WriteLine("/ Name: " + meet_data.Name);
											Console.WriteLine("/ Start date: " + meet_data.Start_date);
											Console.WriteLine("/ End date: " + meet_data.End_date);
											Console.WriteLine("/ Members:                                          /");

											for (int a = 0; a < members.Length; a++)
											{

												Console.WriteLine("/   " + members[a] + "  " + dates[a]);
											}

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/--------------------           --------------------/");
											Console.WriteLine("/                                                   /");
											exist = true;
										}
									}

									else
									{

										d++;
									}

									if (d == 200 && exist == false)
									{

										Console.WriteLine("/                                                   /");
										Console.WriteLine("/               No such meetings found              /");
										Console.WriteLine("/                                                   /");
										break;
									}

									else if (d == 200)
									{

										break;
									}
								}
							}

							else
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/            Inappropriate filter value             /");
								break;
							}

							break;

						// Will filter by number of members beetween 'from' and 'to' numbers
						case "members between":

							Console.WriteLine("/                                                   /");
							Console.WriteLine("/--------------------           --------------------/");
							Console.WriteLine("/                                                   /");
							Console.WriteLine("/                Enter 'from' members               /");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
							filter_val = Console.ReadLine();
							int tempVal3;

							if (filter_val == "exit")
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/---------------------------------------------------/");
								Console.WriteLine("/                                                   /");
								Console.Write("/ ");
								filter = Console.ReadLine();
								break;
							}

							Console.WriteLine("/                                                   /");
							Console.WriteLine("/                 Enter 'to' members                /");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
							string filter_val1 = Console.ReadLine();
							int tempVal4;

							if (filter_val != null && int.TryParse(filter_val, out tempVal3) && int.TryParse(filter_val1, out tempVal4))
							{

								for (int i = 0; i < int.MaxValue; i++)
								{

									if (File.Exists(@"meetingData/meeting_data" + i.ToString() + ".json"))
									{

										exist = false;
										j = 0;
										List<string> tempListMembers = new List<string>();
										List<string> tempListDates = new List<string>();
										StreamReader r = new StreamReader(@"meetingData/meeting_data" + i.ToString() + ".json");
										string jsonString = r.ReadLine();
										MeetingData meet_data = JsonConvert.DeserializeObject<MeetingData>(jsonString);
										string srString;
										string[] members = new string[100];
										string srDates;
										string[] dates = new string[100];

										r.Dispose();
										r.Close();
										GC.Collect();
										GC.WaitForPendingFinalizers();

										if (File.Exists(@"memberData/member_data" + i.ToString() + ".json"))
										{

											StreamReader sr = new StreamReader(@"memberData/member_data" + i.ToString() + ".json");
											srString = sr.ReadLine();
											StreamReader ssr = new StreamReader(@"dateData/date_data" + i.ToString() + ".json");
											srDates = ssr.ReadLine();

											if (srString != null && srDates != null)
											{

												string[] temp = srString.Split(',');
												string[] temp1 = srDates.Split(',');

												for (int a = 0; a < temp.Length; a++)
												{

													members[a] = temp[a];
													members[a] = members[a].Remove(0, 1);
													members[a] = members[a].Remove(members[a].Length - 1, 1);

													dates[a] = temp1[a];
													dates[a] = dates[a].Remove(0, 1);
													dates[a] = dates[a].Remove(dates[a].Length - 1, 1);
												}
											}

											sr.Dispose();
											sr.Close();
											ssr.Dispose();
											ssr.Close();
											GC.Collect();
											GC.WaitForPendingFinalizers();

											foreach (string mem in members)
											{

												if (!string.IsNullOrEmpty(mem))
												{

													tempListMembers.Add(mem);
												}

											}

											foreach (string dat in dates)
											{

												if (!string.IsNullOrEmpty(dat))
												{

													tempListDates.Add(dat);
												}

											}

											members = tempListMembers.ToArray();
											dates = tempListDates.ToArray();
										}

										if (members.Length >= tempVal3 && members.Length <= tempVal4)
										{

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/ #" + i.ToString());
											Console.WriteLine("/ Name: " + meet_data.Name);
											Console.WriteLine("/ Start date: " + meet_data.Start_date);
											Console.WriteLine("/ End date: " + meet_data.End_date);
											Console.WriteLine("/ Members:                                          /");

											for (int a = 0; a < members.Length; a++)
											{

												Console.WriteLine("/   " + members[a] + "  " + dates[a]);
											}

											Console.WriteLine("/                                                   /");
											Console.WriteLine("/--------------------           --------------------/");
											Console.WriteLine("/                                                   /");
											exist = true;
										}
									}

									else
									{

										d++;
									}

									if (d == 200 && exist == false)
									{

										Console.WriteLine("/                                                   /");
										Console.WriteLine("/               No such meetings found              /");
										Console.WriteLine("/                                                   /");
										break;
									}

									else if (d == 200)
									{

										break;
									}
								}
							}

							else
							{

								Console.WriteLine("/                                                   /");
								Console.WriteLine("/            Inappropriate filter value             /");
								break;
							}

							break;

						// Exit the list
						case "exit":

							Console.WriteLine("/                                                   /");
							Console.WriteLine("/////////////////////////////////////////////////////");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
							command = Console.ReadLine();
							loop = false;
							break;

						// Default option if inappropriate filter entered
						default:

							Console.WriteLine("/                                                   /");
							Console.WriteLine("/             There is no such filter               /");
							Console.WriteLine("/                                                   /");
							Console.WriteLine("/--------------------           --------------------/");
							Console.WriteLine("/                                                   /");
							Console.Write("/ ");
							filter = Console.ReadLine();
							break;
					}
				}

				break;

			// Exit the program
			case "exit":

				exit = true;
				break;

			// Default option if inappropriate command entered
			default:

				Console.WriteLine("/                                                   /");
				Console.WriteLine("/             There is no such command              /");
				Console.WriteLine("/                                                   /");
				Console.WriteLine("/////////////////////////////////////////////////////");
				Console.WriteLine("/                                                   /");
				Console.Write("/ ");
				command = Console.ReadLine();
				break;
		}
	}
}

// Class to store meeting data
public class MeetingData
{

	public string Name { get; set; }
	public string Responsible_person { get; set; }
	public string Description { get; set; }
	public string Category { get; set; }
	public string Type { get; set; }
	public string Start_date { get; set; }
	public string End_date { get; set; }
}