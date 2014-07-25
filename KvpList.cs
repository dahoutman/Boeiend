/*
 * Created by SharpDevelop.
 * User: Daan
 * Date: 22-7-2014
 * Time: 21:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Boeiend
{
	public class Kvp <TKey, TValue>
	{
		public TKey Key				{get; set;}
		public TValue Value			{get; set;}
		
		public Kvp(TKey pKey, TValue pValue)
		{
			this.Key = pKey;
			this.Value = pValue;
		}
	}
	/// <summary>
	/// Description of KvpList.
	/// </summary>
	public class KvpList <TKey, TValue> : List<Kvp<TKey, TValue>>
	{
		public bool ContainsKey(TKey pKey)
		{
			foreach (var lKvp in this)
			{
				if (pKey.Equals(lKvp.Key))
				{
					return true;
				}
			}
			
			return false;
		}
		
		public void Insert(int lIndex, TKey pKey, TValue pValue)
		{
			if (this.ContainsKey(pKey))
			{
				throw(new System.ArgumentException("Key already exist"));
			}
			base.Insert(lIndex,	new Kvp<TKey, TValue>(pKey, pValue));
		}
		
		public void Add(TKey pKey, TValue pValue)
		{
			if (this.ContainsKey(pKey))
			{
				throw(new System.ArgumentException("Key already exist"));
			}
			base.Add(new Kvp<TKey, TValue>(pKey, pValue));
		}
		
		public new void Add(Kvp<TKey, TValue> pKvp)
		{
			if (this.ContainsKey(pKvp.Key))
			{
				throw(new System.ArgumentException("Key already exist"));
			}
			base.Add(pKvp);
		}
		
		public List<TKey> Keys()
		{
			var lList = new List<TKey>();
			foreach (var lKvp in this)
			{
				lList.Add(lKvp.Key);
			}
			return lList;
		}
		
		public void SetValue(TKey pKey, TValue pValue)
		{
			foreach(var lKvp in this)
			{
				if (lKvp.Key.Equals(pKey))
				{
					lKvp.Value = pValue;
				}
			}
		}

		public TValue GetValue(TKey pKey)
		{
			foreach(var lKvp in this)
			{
				if (lKvp.Key.Equals(pKey))
				{
					return lKvp.Value;
				}
			}
			return default(TValue);
		}
		
		public TValue this[TKey pKey]
		{
		    get
		    {
		        return GetValue(pKey);
		    }
		    set
		    {
		        SetValue(pKey,value);
		    }
		}
	}
}
