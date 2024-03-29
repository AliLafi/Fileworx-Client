﻿using System;

namespace FileworxObjects.DTOs
{
    public class BusinessObjectDTO
    {
        public int ID { get; set; }
        public int LastModifier { get; set; }
        public int Creator { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ClassID { get; set; }

        public BusinessObjectDTO(int iD, int lastModifier, int creator, string name, string description, DateTime created, DateTime lastModified, int classID)
        {
            ID = iD;
            LastModifier = lastModifier;
            Creator = creator;
            Name = name;
            Description = description;
            Created = created;
            ModifyDate = lastModified;
            ClassID = classID;

        }
        public BusinessObjectDTO(int lastModifier, int creator, string name, string description, DateTime created, DateTime lastModified, int classID)
        {
            ID = -1;
            LastModifier = lastModifier;
            Creator = creator;
            Name = name;
            Description = description;
            Created = created;
            ModifyDate = lastModified;
            ClassID = classID;

        }
        public BusinessObjectDTO()
        {
        }
    }
}
