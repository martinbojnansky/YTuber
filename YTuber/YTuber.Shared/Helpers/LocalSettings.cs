﻿using System;
using System.Collections.Generic;
using Windows.Foundation.Collections;
using Windows.Storage;
using YTuber.IoC;

namespace YTuber.Helpers
{
    public class LocalSettings : IResolvable
    {
        private ApplicationDataContainer localSettings => ApplicationData.Current.LocalSettings;
        private StorageFolder localFolder => ApplicationData.Current.LocalFolder;

        public ApplicationDataContainer GetContainer(string container)
        {
            if (string.IsNullOrWhiteSpace(container))
            {
                if (!localSettings.Containers.ContainsKey(container))
                { 
                    localSettings.CreateContainer(container, ApplicationDataCreateDisposition.Always);
                }

                return localSettings.Containers[container];
            }
            else
            {
                return localSettings;
            }
        }

        public void SetValue(string key, object value, string container = null)
        {
            var applicationDataContainer = GetContainer(container);

            if (applicationDataContainer.Values.ContainsKey(key))
            {
                applicationDataContainer.Values[key] = value;
            }
            else
            {
                applicationDataContainer.Values.Add(key, value);
            }
        }

        public object GetValue(string key, string container = null)
        {
            var applicationDataContainer = GetContainer(container);

            if (applicationDataContainer.Values.ContainsKey(key))
            {
                return applicationDataContainer.Values[key];
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public IPropertySet GetContainerValues(string container)
        {
            if (localSettings.Containers.ContainsKey(container))
            {
                return localSettings.Containers[container].Values;
            }
            else
            {
                return localSettings.CreateContainer(container, ApplicationDataCreateDisposition.Always).Values;
            }
        }

        public void RemoveKey(string key, string container = null)
        {
            var applicationDataContainer = GetContainer(container);

            if (applicationDataContainer.Values.ContainsKey(key))
            {
                applicationDataContainer.Values.Remove(key);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public void RemoveContainer(string container)
        {
            if (localSettings.Containers.ContainsKey(container))
            {
                localSettings.DeleteContainer(container);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
