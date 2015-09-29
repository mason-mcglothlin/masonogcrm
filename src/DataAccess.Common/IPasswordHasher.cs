using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasonOgCRM.DataAccess.Common
{
	public interface IPasswordHasher
	{
		string CreateHash(string password);
		bool ValidatePassword(string password, string correctHash);
    }
}
