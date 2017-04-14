using System;
using Newtonsoft.Json;

namespace AppVersion
{
	class VersionProfile
	{
		object syncRoot = new object();

		int major;
		public int Major
		{
			get
			{
				return major;
			}

			set
			{
				major = value;
				SyncProps();
			}
		}

		int minor;
		public int Minor
		{
			get
			{
				return minor;
			}

			set
			{
				minor = value;
				SyncProps();
			}
		}

		int patch;
		public int Patch
		{
			get
			{
				return patch;
			}

			set
			{
				patch = value;
				SyncProps();
			}
		}

		string preRelease;
		public string PreRelease
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(preRelease)) {
					return "-" + preRelease;
				}
				return preRelease;
			}

			set
			{
				preRelease = value;
				SyncProps();
			}
		}

		string metadata;
		public string Metadata
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(metadata)) {
					return "+" + metadata;
				}
				return metadata;
			}

			set
			{
				metadata = value;
				SyncProps();
			}
		}

		[JsonIgnore]
		public DateTime CreateDate { get; private set; }

		[JsonIgnore]
		public DateTime UpdateDate { get; private set; }

		[JsonIgnore]
		public string Version { get; private set; }

		[JsonIgnore]
		public string InfoVersion { get; private set; }

		[JsonIgnore]
		public int IosBuildNumber { get;  private set; }

		[JsonIgnore]
		public int AndroidBuildNumber { get; private set; }

		[JsonIgnore]
		public string IosVersion { get;  private set; }

		[JsonIgnore]
		public string AndroidVersion { get;  private set; }

		void SyncProps()
		{
			lock(syncRoot)
			{
				UpdateDate = DateTime.UtcNow;
				Version = string.Format("{0}.{1}.{2}", major, major, patch, preRelease, metadata);
				InfoVersion = string.Format("{0}.{1}.{2}{3}{4}", major, major, patch, preRelease, metadata);
				IosBuildNumber = int.Parse(string.Format("{0}{1}{2}", major, major, patch));
				AndroidBuildNumber = int.Parse(string.Format("{0}{1}{2}", major, major, patch));
				IosVersion = string.Format("{0}.{1}.{2}{3}{4}", major, major, patch, preRelease, metadata);
				AndroidVersion = string.Format("{0}.{1}.{2}{3}{4}", major, major, patch, preRelease, metadata);
			}
		}

		VersionProfile()
		{
			var timestamp = DateTime.UtcNow;
			CreateDate = timestamp;
			UpdateDate = timestamp;
			Major = 1;
		}

		public static VersionProfile Create()
		{
			return new VersionProfile();
		}

		public static VersionProfile Create(string jsonSerialized)
		{
			var versionProfle = JsonConvert.DeserializeObject<VersionProfile>(jsonSerialized);
			return versionProfle;
		}

		[JsonIgnore]
		public string Serialized
		{
			get { 
				return JsonConvert.SerializeObject(this); 
			}
		}

		public int IncrementMajor()
		{
			return ++Major;
		}

		public int IncrementMinor()
		{
			return ++Minor;
		}

		public int IncrementPatch()
		{
			return ++Patch;
		}
	}
}