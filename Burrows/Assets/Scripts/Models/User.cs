using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class User {
	public string email;
	public int exp;
	public string fullname;
	public int highscore;
	public int money;
	public string password;
	public string location;

	public string toString() {
		string retval = "";
		retval += " " + email;
		retval += " " + exp.ToString();
		retval += " " + fullname;
		retval += " " + highscore.ToString();
		retval += " " + money.ToString();
		retval += " " + password;
		retval += " " + location;

		return retval;
	}
}
