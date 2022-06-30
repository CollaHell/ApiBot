using System.Collections.Generic;

namespace ApiBot.Models.Bot
{
  

        public class ResponseInfo
        {
            public class From
            {
                public long Id { get; set; }
                public bool Is_Bot { get; set; }
                public string First_Name { get; set; }
                public string Last_Name { get; set; }
                public string Username { get; set; }
                public string Language_Code { get; set; }
            }
            public class Thumb
            {
                public string File_Id { get; set; }
                public string File_Unique_Id { get; set; }
                public int File_Size { get; set; }
                public int Width { get; set; }
                public int Height { get; set; }
            }

            public class Chat
            {
                public long Id { get; set; }
                public string First_Name { get; set; }
                public string Last_Name { get; set; }
                public string Username { get; set; }
                public string Type { get; set; }
            }
            public class Photo
            {
                public string File_Id { get; set; }
                public string File_Unique_Id { get; set; }
                public int File_Size { get; set; }
                public int Width { get; set; }
                public int Height { get; set; }
            }
            public class Audio
            {
                public int Duration { get; set; }
                public string File_Name { get; set; }
                public string Mime_Type { get; set; }
                public string File_Id { get; set; }
                public string File_Unique_Id { get; set; }
                public int File_Size { get; set; }
            }
            public class Video
            {
                public int Duration { get; set; }
                public int Width { get; set; }
                public int Height { get; set; }
                public string File_Name { get; set; }
                public string Mime_Type { get; set; }
                public Thumb Thumb { get; set; }
                public string File_Id { get; set; }
                public string File_Unique_Id { get; set; }
                public int File_Size { get; set; }
            }
            public class Voice
            {
                public int Duration { get; set; }
                public string Mime_Type { get; set; }
                public string File_Id { get; set; }
                public string File_Unique_Id { get; set; }
                public int File_Size { get; set; }
            }
            public class Animation
            {
                public string File_Name { get; set; }
                public string Mime_Type { get; set; }
                public int Duration { get; set; }
                public int Width { get; set; }
                public int Height { get; set; }
                public Thumb Thumb { get; set; }
                public string File_Id { get; set; }
                public string File_Unique_Id { get; set; }
                public int File_Size { get; set; }
            }
            public class VideoNote
            {
                public int Duration { get; set; }
                public int Length { get; set; }
                public Thumb Thumb { get; set; }
                public string File_Id { get; set; }
                public string File_Unique_Id { get; set; }
                public int File_Size { get; set; }
            }
            public class Document
            {
                public string File_Name { get; set; }
                public string Mime_Type { get; set; }
                public Thumb Thumb { get; set; }
                public string File_Id { get; set; }
                public string File_Unique_Id { get; set; }
                public int File_Size { get; set; }
            }
            public class Option
            {
                public string Text { get; set; }
                public int Voter_Count { get; set; }
            }
            public class Poll
            {
                public string Id { get; set; }
                public string Question { get; set; }
                public List<Option> Options { get; set; }
                public int Total_Voter_Count { get; set; }
                public bool Is_Closed { get; set; }
                public bool Is_Anonymous { get; set; }
                public string Type { get; set; }
                public bool Allows_Multiple_Answers { get; set; }
            }
            public class Sticker
            {
                public int Width { get; set; }
                public int Height { get; set; }
                public string Emoji { get; set; }
                public string Set_Name { get; set; }
                public bool Is_Animated { get; set; }
                public Thumb Thumb { get; set; }
                public string File_Id { get; set; }
                public string File_Unique_Id { get; set; }
                public int File_Size { get; set; }
            }
            public class EditedMessage
            {
                public int Message_Id { get; set; }
                public From From { get; set; }
                public Chat Chat { get; set; }
                public int Date { get; set; }
                public int Edit_Date { get; set; }
                public string Media_Group_Id { get; set; }
                public List<Photo> Photo { get; set; }
                public string Text { get; set; }
                public Video Video { get; set; }
                public Voice Voice { get; set; }
                public Audio Audio { get; set; }
                public Animation Animation { get; set; }
                public Document Document { get; set; }
                public string Caption { get; set; }
            }
            public class ReplyToMessage
            {
                public int Message_Id { get; set; }
                public From From { get; set; }
                public Chat Chat { get; set; }
                public int Date { get; set; }
                public string Text { get; set; }
            }
            public class Message
            {
                public int Message_Id { get; set; }
                public From From { get; set; }
                public Chat Chat { get; set; }
                public int Date { get; set; }
                public string Forward_Sender_Name { get; set; }
                public int Forward_Date { get; set; }
                public ReplyToMessage Reply_To_Message { get; set; }
                public string Text { get; set; }
                public List<Photo> Photo { get; set; }
                public string Media_Group_Id { get; set; }
                public Audio Audio { get; set; }
                public Sticker Sticker { get; set; }
                public Voice Voice { get; set; }
                public Video Video { get; set; }
                public Animation Animation { get; set; }
                public Document Document { get; set; }
                public VideoNote Video_Note { get; set; }
                public string Caption { get; set; }
            }

            public class Result
            {
                public long Update_Id { get; set; }
                public Message Message { get; set; }
                public EditedMessage Edited_Message { get; set; }
            }
        }


        public class ImgInfo
        {
            public class Result
            {
                public string file_id { get; set; }
                public string file_unique_id { get; set; }
                public int file_size { get; set; }
                public string file_path { get; set; }
            }

            public class Root
            {
                public bool ok { get; set; }
                public Result result { get; set; }
            }


        }
    }

