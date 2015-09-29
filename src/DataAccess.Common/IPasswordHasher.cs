using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasonOgCRM.DataAccess.Common
{
	/// <summary>
	/// Interface describing the functionality a password hasher must have.
	/// </summary>
	public interface IPasswordHasher
	{
		/// <summary>
		/// Function to create a hashed password (including salt).
		/// </summary>
		/// <param name="password">The password to hash.</param>
		/// <returns>Hashed and salted version of the password.</returns>
		string CreateHash(string password);

		/// <summary>
		/// Validates a password is correct by comparing it to the hashed and salted password.
		/// </summary>
		/// <param name="password">The password to verify.</param>
		/// <param name="correctHash">The hashed and salted password to verify against.</param>
		/// <returns>True if the password matches the hash, False otherwise.</returns>
		bool ValidatePassword(string password, string correctHash);
    }
}
