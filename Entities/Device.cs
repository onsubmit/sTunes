//-----------------------------------------------------------------------
// <copyright file="Device.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Entities
{
    /// <summary>
    /// Represents a device
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class
        /// </summary>
        /// <param name="id">The device ID</param>
        /// <param name="name">The device name</param>
        public Device(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Gets the device's ID
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the device's name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Provides a string representation for the device
        /// </summary>
        /// <returns>The device's name</returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
