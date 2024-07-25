// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/schema.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace ScheduledMessagesHandler {

  /// <summary>Holder for reflection information generated from Protos/schema.proto</summary>
  public static partial class SchemaReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/schema.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SchemaReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChNQcm90b3Mvc2NoZW1hLnByb3RvEgpUcmFubWl0dGVyIskBCgdNZXNzYWdl",
            "EhAKCGNsaWVudElEGAEgASgJEg4KBmFwaUtleRgCIAEoCRINCgVtc2dJZBgD",
            "IAEoCRITCgtwaG9uZU51bWJlchgEIAEoCRIVCg1sb2NhbFByaW9yaXR5GAUg",
            "ASgFEgwKBHRleHQYBiABKAkSCwoDdGFnGAcgASgJEgwKBHllYXIYCCABKAUS",
            "DQoFbW9udGgYCSABKAUSCwoDZGF5GAogASgFEgwKBGhvdXIYCyABKAUSDgoG",
            "bWludXRlGAwgASgFIjcKD0Fja25vd2xlZGdlbWVudBIRCglyZXBseUNvZGUY",
            "ASABKAkSEQoJcmVxdWVzdElEGAIgASgJMkkKBVF1ZXVlEkAKDFF1ZXVlTWVz",
            "c2FnZRITLlRyYW5taXR0ZXIuTWVzc2FnZRobLlRyYW5taXR0ZXIuQWNrbm93",
            "bGVkZ2VtZW50QhuqAhhTY2hlZHVsZWRNZXNzYWdlc0hhbmRsZXJiBnByb3Rv",
            "Mw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::ScheduledMessagesHandler.Message), global::ScheduledMessagesHandler.Message.Parser, new[]{ "ClientID", "ApiKey", "MsgId", "PhoneNumber", "LocalPriority", "Text", "Tag", "Year", "Month", "Day", "Hour", "Minute" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::ScheduledMessagesHandler.Acknowledgement), global::ScheduledMessagesHandler.Acknowledgement.Parser, new[]{ "ReplyCode", "RequestID" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class Message : pb::IMessage<Message>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Message> _parser = new pb::MessageParser<Message>(() => new Message());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<Message> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ScheduledMessagesHandler.SchemaReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Message() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Message(Message other) : this() {
      clientID_ = other.clientID_;
      apiKey_ = other.apiKey_;
      msgId_ = other.msgId_;
      phoneNumber_ = other.phoneNumber_;
      localPriority_ = other.localPriority_;
      text_ = other.text_;
      tag_ = other.tag_;
      year_ = other.year_;
      month_ = other.month_;
      day_ = other.day_;
      hour_ = other.hour_;
      minute_ = other.minute_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Message Clone() {
      return new Message(this);
    }

    /// <summary>Field number for the "clientID" field.</summary>
    public const int ClientIDFieldNumber = 1;
    private string clientID_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string ClientID {
      get { return clientID_; }
      set {
        clientID_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "apiKey" field.</summary>
    public const int ApiKeyFieldNumber = 2;
    private string apiKey_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string ApiKey {
      get { return apiKey_; }
      set {
        apiKey_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "msgId" field.</summary>
    public const int MsgIdFieldNumber = 3;
    private string msgId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string MsgId {
      get { return msgId_; }
      set {
        msgId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "phoneNumber" field.</summary>
    public const int PhoneNumberFieldNumber = 4;
    private string phoneNumber_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string PhoneNumber {
      get { return phoneNumber_; }
      set {
        phoneNumber_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "localPriority" field.</summary>
    public const int LocalPriorityFieldNumber = 5;
    private int localPriority_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int LocalPriority {
      get { return localPriority_; }
      set {
        localPriority_ = value;
      }
    }

    /// <summary>Field number for the "text" field.</summary>
    public const int TextFieldNumber = 6;
    private string text_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Text {
      get { return text_; }
      set {
        text_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "tag" field.</summary>
    public const int TagFieldNumber = 7;
    private string tag_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Tag {
      get { return tag_; }
      set {
        tag_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "year" field.</summary>
    public const int YearFieldNumber = 8;
    private int year_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Year {
      get { return year_; }
      set {
        year_ = value;
      }
    }

    /// <summary>Field number for the "month" field.</summary>
    public const int MonthFieldNumber = 9;
    private int month_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Month {
      get { return month_; }
      set {
        month_ = value;
      }
    }

    /// <summary>Field number for the "day" field.</summary>
    public const int DayFieldNumber = 10;
    private int day_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Day {
      get { return day_; }
      set {
        day_ = value;
      }
    }

    /// <summary>Field number for the "hour" field.</summary>
    public const int HourFieldNumber = 11;
    private int hour_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Hour {
      get { return hour_; }
      set {
        hour_ = value;
      }
    }

    /// <summary>Field number for the "minute" field.</summary>
    public const int MinuteFieldNumber = 12;
    private int minute_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Minute {
      get { return minute_; }
      set {
        minute_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as Message);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(Message other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ClientID != other.ClientID) return false;
      if (ApiKey != other.ApiKey) return false;
      if (MsgId != other.MsgId) return false;
      if (PhoneNumber != other.PhoneNumber) return false;
      if (LocalPriority != other.LocalPriority) return false;
      if (Text != other.Text) return false;
      if (Tag != other.Tag) return false;
      if (Year != other.Year) return false;
      if (Month != other.Month) return false;
      if (Day != other.Day) return false;
      if (Hour != other.Hour) return false;
      if (Minute != other.Minute) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (ClientID.Length != 0) hash ^= ClientID.GetHashCode();
      if (ApiKey.Length != 0) hash ^= ApiKey.GetHashCode();
      if (MsgId.Length != 0) hash ^= MsgId.GetHashCode();
      if (PhoneNumber.Length != 0) hash ^= PhoneNumber.GetHashCode();
      if (LocalPriority != 0) hash ^= LocalPriority.GetHashCode();
      if (Text.Length != 0) hash ^= Text.GetHashCode();
      if (Tag.Length != 0) hash ^= Tag.GetHashCode();
      if (Year != 0) hash ^= Year.GetHashCode();
      if (Month != 0) hash ^= Month.GetHashCode();
      if (Day != 0) hash ^= Day.GetHashCode();
      if (Hour != 0) hash ^= Hour.GetHashCode();
      if (Minute != 0) hash ^= Minute.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (ClientID.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ClientID);
      }
      if (ApiKey.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ApiKey);
      }
      if (MsgId.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(MsgId);
      }
      if (PhoneNumber.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(PhoneNumber);
      }
      if (LocalPriority != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(LocalPriority);
      }
      if (Text.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(Text);
      }
      if (Tag.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(Tag);
      }
      if (Year != 0) {
        output.WriteRawTag(64);
        output.WriteInt32(Year);
      }
      if (Month != 0) {
        output.WriteRawTag(72);
        output.WriteInt32(Month);
      }
      if (Day != 0) {
        output.WriteRawTag(80);
        output.WriteInt32(Day);
      }
      if (Hour != 0) {
        output.WriteRawTag(88);
        output.WriteInt32(Hour);
      }
      if (Minute != 0) {
        output.WriteRawTag(96);
        output.WriteInt32(Minute);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (ClientID.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ClientID);
      }
      if (ApiKey.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ApiKey);
      }
      if (MsgId.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(MsgId);
      }
      if (PhoneNumber.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(PhoneNumber);
      }
      if (LocalPriority != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(LocalPriority);
      }
      if (Text.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(Text);
      }
      if (Tag.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(Tag);
      }
      if (Year != 0) {
        output.WriteRawTag(64);
        output.WriteInt32(Year);
      }
      if (Month != 0) {
        output.WriteRawTag(72);
        output.WriteInt32(Month);
      }
      if (Day != 0) {
        output.WriteRawTag(80);
        output.WriteInt32(Day);
      }
      if (Hour != 0) {
        output.WriteRawTag(88);
        output.WriteInt32(Hour);
      }
      if (Minute != 0) {
        output.WriteRawTag(96);
        output.WriteInt32(Minute);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (ClientID.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ClientID);
      }
      if (ApiKey.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ApiKey);
      }
      if (MsgId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(MsgId);
      }
      if (PhoneNumber.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PhoneNumber);
      }
      if (LocalPriority != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(LocalPriority);
      }
      if (Text.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Text);
      }
      if (Tag.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Tag);
      }
      if (Year != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Year);
      }
      if (Month != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Month);
      }
      if (Day != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Day);
      }
      if (Hour != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Hour);
      }
      if (Minute != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Minute);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(Message other) {
      if (other == null) {
        return;
      }
      if (other.ClientID.Length != 0) {
        ClientID = other.ClientID;
      }
      if (other.ApiKey.Length != 0) {
        ApiKey = other.ApiKey;
      }
      if (other.MsgId.Length != 0) {
        MsgId = other.MsgId;
      }
      if (other.PhoneNumber.Length != 0) {
        PhoneNumber = other.PhoneNumber;
      }
      if (other.LocalPriority != 0) {
        LocalPriority = other.LocalPriority;
      }
      if (other.Text.Length != 0) {
        Text = other.Text;
      }
      if (other.Tag.Length != 0) {
        Tag = other.Tag;
      }
      if (other.Year != 0) {
        Year = other.Year;
      }
      if (other.Month != 0) {
        Month = other.Month;
      }
      if (other.Day != 0) {
        Day = other.Day;
      }
      if (other.Hour != 0) {
        Hour = other.Hour;
      }
      if (other.Minute != 0) {
        Minute = other.Minute;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            ClientID = input.ReadString();
            break;
          }
          case 18: {
            ApiKey = input.ReadString();
            break;
          }
          case 26: {
            MsgId = input.ReadString();
            break;
          }
          case 34: {
            PhoneNumber = input.ReadString();
            break;
          }
          case 40: {
            LocalPriority = input.ReadInt32();
            break;
          }
          case 50: {
            Text = input.ReadString();
            break;
          }
          case 58: {
            Tag = input.ReadString();
            break;
          }
          case 64: {
            Year = input.ReadInt32();
            break;
          }
          case 72: {
            Month = input.ReadInt32();
            break;
          }
          case 80: {
            Day = input.ReadInt32();
            break;
          }
          case 88: {
            Hour = input.ReadInt32();
            break;
          }
          case 96: {
            Minute = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            ClientID = input.ReadString();
            break;
          }
          case 18: {
            ApiKey = input.ReadString();
            break;
          }
          case 26: {
            MsgId = input.ReadString();
            break;
          }
          case 34: {
            PhoneNumber = input.ReadString();
            break;
          }
          case 40: {
            LocalPriority = input.ReadInt32();
            break;
          }
          case 50: {
            Text = input.ReadString();
            break;
          }
          case 58: {
            Tag = input.ReadString();
            break;
          }
          case 64: {
            Year = input.ReadInt32();
            break;
          }
          case 72: {
            Month = input.ReadInt32();
            break;
          }
          case 80: {
            Day = input.ReadInt32();
            break;
          }
          case 88: {
            Hour = input.ReadInt32();
            break;
          }
          case 96: {
            Minute = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class Acknowledgement : pb::IMessage<Acknowledgement>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Acknowledgement> _parser = new pb::MessageParser<Acknowledgement>(() => new Acknowledgement());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<Acknowledgement> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ScheduledMessagesHandler.SchemaReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Acknowledgement() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Acknowledgement(Acknowledgement other) : this() {
      replyCode_ = other.replyCode_;
      requestID_ = other.requestID_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Acknowledgement Clone() {
      return new Acknowledgement(this);
    }

    /// <summary>Field number for the "replyCode" field.</summary>
    public const int ReplyCodeFieldNumber = 1;
    private string replyCode_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string ReplyCode {
      get { return replyCode_; }
      set {
        replyCode_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "requestID" field.</summary>
    public const int RequestIDFieldNumber = 2;
    private string requestID_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string RequestID {
      get { return requestID_; }
      set {
        requestID_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as Acknowledgement);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(Acknowledgement other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ReplyCode != other.ReplyCode) return false;
      if (RequestID != other.RequestID) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (ReplyCode.Length != 0) hash ^= ReplyCode.GetHashCode();
      if (RequestID.Length != 0) hash ^= RequestID.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (ReplyCode.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ReplyCode);
      }
      if (RequestID.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(RequestID);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (ReplyCode.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ReplyCode);
      }
      if (RequestID.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(RequestID);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (ReplyCode.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ReplyCode);
      }
      if (RequestID.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(RequestID);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(Acknowledgement other) {
      if (other == null) {
        return;
      }
      if (other.ReplyCode.Length != 0) {
        ReplyCode = other.ReplyCode;
      }
      if (other.RequestID.Length != 0) {
        RequestID = other.RequestID;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            ReplyCode = input.ReadString();
            break;
          }
          case 18: {
            RequestID = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            ReplyCode = input.ReadString();
            break;
          }
          case 18: {
            RequestID = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
