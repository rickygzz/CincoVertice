﻿using CincoVertice.Utils.Config.Tokens;
using CincoVertice.Utils.Lexer;
using CincoVertice.Utils.Lexer.Tokens;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CincoVertice.Utils.Config
{
    public class ConfigItems
    {
        /// <summary>
        /// List with indexes of all keys processed in Process().
        /// </summary>
        private readonly List<ConfigItemModel> _keyValueList = new();

        private readonly ConfigLexer _lexer;

        public ConfigItems(ConfigLexer lexer)
        {
            _lexer = lexer;
        }

        /// <summary>
        /// Gets keys count.
        /// </summary>
        /// <returns>The number of keys on config file.</returns>
        public int KeysCount
        {
            get
            {
                return _keyValueList.Count;
            }
        }

        public void Clear()
        {
            _keyValueList.Clear();
        }

        public void AddKeyValue(GenericToken key, GenericToken value)
        {
            var model = new ConfigItemModel
            {
                Key = key,
                Value = value,
            };

            _keyValueList.Add(model);
        }

        public void AddKeyValue(ConfigItemModel model)
        {
            _keyValueList.Add(model);
        }

        /// <summary>
        /// Gets the index of the first key found matching provided key name.
        /// </summary>
        /// <param name="key">The key name to look for.</param>
        /// <returns>Returns index if key is found, otherwise -1.</returns>
        public int GetKeyIndex(string key)
        {
            // Loop all tokens type = TokenType.Key.
            for (int i = 0; i < _keyValueList.Count; i++)
            {
                if (_lexer.Substring(_keyValueList[i].Key.StartPos, _keyValueList[i].Key.Length)
                    .Equals(key, StringComparison.InvariantCultureIgnoreCase))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Gets the key name for the provided key index.
        /// </summary>
        /// <param name="keyIndex">The key index to look for.</param>
        /// <returns>Returns key name if found, otherwise returns string.Empty.</returns>
        public string GetKeyName(int keyIndex)
        {
            if (keyIndex >= _keyValueList.Count || keyIndex < 0)
            {
                return string.Empty;
            }

            return _lexer.Substring(_keyValueList[keyIndex].Key.StartPos, _keyValueList[keyIndex].Key.Length);
        }

        /// <summary>
        /// Gets the value of the first key found matching provided key name.
        /// </summary>
        /// <param name="key">The key name to look for.</param>
        /// <returns>Returns value if valid key-value pair token is found, otherwise returns string.Empty.</returns>
        public string GetValue(string key)
        {
            for (int i = 0; i < _keyValueList.Count; i++)
            {
                if (_lexer.Substring(_keyValueList[i].Key.StartPos, _keyValueList[i].Key.Length)
                    .Equals(key, StringComparison.InvariantCultureIgnoreCase)
                    && _keyValueList[i].Value.Type > GenericTokenType.Null
                    && _keyValueList[i].Value.Type < ConfigTokenType.ErrorUnknown)
                {
                    return _lexer.Substring(_keyValueList[i].Value.StartPos, _keyValueList[i].Value.Length);
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Get value from key index.
        /// </summary>
        /// <param name="keyIndex">Index of key.</param>
        /// <returns>Return key value if it exists, otherwise returns string.Empty.</returns>
        public string GetValue(int keyIndex)
        {
            if (keyIndex >= _keyValueList.Count || keyIndex < 0)
            {
                return string.Empty;
            }

            if (_keyValueList[keyIndex].Value.Type > GenericTokenType.Null
                && _keyValueList[keyIndex].Value.Type < ConfigTokenType.ErrorUnknown)
            {
                return _lexer.Substring(_keyValueList[keyIndex].Value.StartPos, _keyValueList[keyIndex].Value.Length);
            }

            return string.Empty;
        }

        /// <summary>
        /// Get value type from index.
        /// </summary>
        /// <param name="keyIndex">Index of key.</param>
        /// <returns>Returns key value if it exists, otherwise returns ConfigTokenType.Null.</returns>
        public int GetValueType(int keyIndex)
        {
            if (keyIndex >= _keyValueList.Count || keyIndex < 0)
            {
                return GenericTokenType.Null;
            }

            return _keyValueList[keyIndex].Value.Type;
        }

        public T GetValues<T>()
            where T : class, new()
        {
            T result = new T();
            var fields = typeof(T).GetFields();

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(int) && int.TryParse(GetValue(field.Name), out int i))
                {
                    field.SetValue(result, i);
                }
                else if (field.FieldType == typeof(long) && long.TryParse(GetValue(field.Name), out long l))
                {
                    field.SetValue(result, l);
                }
                else if (field.FieldType == typeof(decimal) && decimal.TryParse(GetValue(field.Name), out decimal d))
                {
                    field.SetValue(result, d);
                }
                else if (field.FieldType == typeof(float) && float.TryParse(GetValue(field.Name), out float f))
                {
                    field.SetValue(result, f);
                }
                else if (field.FieldType == typeof(double) && double.TryParse(GetValue(field.Name), out double doubleVal))
                {
                    field.SetValue(result, doubleVal);
                }
                else if (field.FieldType == typeof(bool) && bool.TryParse(GetValue(field.Name), out bool b))
                {
                    field.SetValue(result, b);
                }
                else
                {
                    field.SetValue(result, GetValue(field.Name));
                }
            }

            return result;
        }

        /// <summary>
        /// Set. If key exists, it modifies its value. Otherwise, appends as new key.
        /// </summary>
        /// <param name="key">key.</param>
        /// <param name="value">value.</param>
        public void Set(string key, string value)
        {
            ConfigLexer keyLexer = new ConfigLexer(key);

            GenericToken token = keyLexer.GetKey();

            if (token.Type != GenericTokenType.Null)
            {
                ConfigLexer valueLexer = new ConfigLexer(value);

                GenericToken valueToken = valueLexer.GetNumericValue();
            }
        }

        public void Set<T>(T instance)
            where T : class, new()
        {
            var fields = typeof(T).GetFields();
            foreach (FieldInfo field in fields)
            {
                Set(field.Name, field.GetValue(instance)?.ToString()!);
            }
        }

        public void Delete(string key)
        {
            int i = GetKeyIndex(key);

            if (i != -1)
            {
                _keyValueList.RemoveAt(i);
            }
        }
    }
}
