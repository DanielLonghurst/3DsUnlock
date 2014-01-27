using System;



namespace ThreeDSUnlockLib
{
	/// <summary>
	/// My class.
	/// </summary>
	/// <remarks>
	/// Based on code from: https://github.com/3dshax/ctr/blob/master/parentool/main.c
	/// </remarks>
	public class Unlocker
   {
		private static ulong calculate_master_key(string generator)
		{
			UInt32[] table = new UInt32[256];
			UInt32 data;
			UInt32 y;
			byte x;
			UInt64 yll;
			UInt32 yhi;

			for(int i=0; i<256; i++)
			{
				data = (UInt32)i;
				for(int j=0; j<4; j++)
				{
					if ((data & 1) != 0)
						data =  0xEDBA6320 ^ (data>>1);
					else
						data = data>>1;

					if ((data & 1) != 0)
						data = 0xEDBA6320 ^ (data>>1);
					else
						data = data>>1;
				}

				table[i] = data;
			}

			y = 0xFFFFFFFF;
			x = Convert.ToByte(generator[0]);
			for(int i=0; i<4; i++)
			{
				x = (byte)(x ^ y);
				y = table[x] ^ (y>>8);
				x = (byte)(Convert.ToByte(generator[1+i*2]) ^ y);
				y = table[x] ^ (y>>8);
				x = Convert.ToByte(generator[2+i*2]);
			}

			y ^= 0xAAAA;
			y += 0x1657;

			yll = (ulong)y;
			yll = (yll+1) * 0xA7C5AC47ULL;
			yhi = (uint)(yll>>48);
			yhi *= 0xFFFFF3CB;
			y += (uint)(yhi<<5);

			return y;
		}

		public static void GetUnlockKey(ulong UserCode, out string MasterKey, out string ServiceCode)
		{
			string generator;
			ulong servicecode, month, day, masterkey;

//			3DsUnlockLib("usage: <servicecode> <month> <day>\n");
			// Jan 25, 2014 adn 36265820 will yeild 80508 and 01255820

			servicecode = UserCode; // 36265820;
			DateTime today = DateTime.Now;
			month = (ulong)today.Month;
			day = (ulong)today.Day;

			servicecode %= 10000;
			month %= 100;
			day %= 100;

			//sprintf((char*)generator, "%02d%02d%04d", month, day, servicecode);
			ServiceCode = string.Format("{0:d2}{1:d2}{2:d4}\0", month, day, servicecode);
			masterkey = calculate_master_key(ServiceCode);
			MasterKey = masterkey.ToString("d5");
		}
   }
}

