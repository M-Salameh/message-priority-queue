// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/validator.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace GrpcMessageNode {

  /// <summary>Holder for reflection information generated from Protos/validator.proto</summary>
  public static partial class ValidatorReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/validator.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ValidatorReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChZQcm90b3MvdmFsaWRhdG9yLnByb3RvEglWYWxpZGF0b3IiiAEKD01lc3Nh",
            "Z2VNZXRhRGF0YRIQCghjbGllbnRJRBgBIAEoCRIOCgZhcGlLZXkYAiABKAkS",
            "CwoDdGFnGAMgASgJEgwKBHllYXIYBCABKAUSDQoFbW9udGgYBSABKAUSCwoD",
            "ZGF5GAYgASgFEgwKBGhvdXIYByABKAUSDgoGbWludXRlGAggASgFIjwKDlZh",
            "bGlkYXRvclJlcGx5EhEKCXJlcGx5Q29kZRgBIAEoCRIXCg9hY2NvdW50UHJp",
            "b3JpdHkYAiABKAUyVAoIVmFsaWRhdGUSSAoPVmFsaWRhdGVNZXNzYWdlEhou",
            "VmFsaWRhdG9yLk1lc3NhZ2VNZXRhRGF0YRoZLlZhbGlkYXRvci5WYWxpZGF0",
            "b3JSZXBseUISqgIPR3JwY01lc3NhZ2VOb2RlYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::GrpcMessageNode.MessageMetaData), global::GrpcMessageNode.MessageMetaData.Parser, new[]{ "ClientID", "ApiKey", "Tag", "Year", "Month", "Day", "Hour", "Minute" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::GrpcMessageNode.ValidatorReply), global::GrpcMessageNode.ValidatorReply.Parser, new[]{ "ReplyCode", "AccountPriority" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class MessageMetaData : pb::IMessage<MessageMetaData>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<MessageMetaData> _parser = new pb::MessageParser<MessageMetaData>(() => new MessageMetaData());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<MessageMetaData> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GrpcMessageNode.ValidatorReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public MessageMetaData() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public MessageMetaData(MessageMetaData other) : this() {
      clientID_ = other.clientID_;
      apiKey_ = other.apiKey_;
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
    public MessageMetaData Clone() {
      return new MessageMetaData(this);
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

    /// <summary>Field number for the "tag" field.</summary>
    public const int TagFieldNumber = 3;
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
    public const int YearFieldNumber = 4;
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
    public const int MonthFieldNumber = 5;
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
    public const int DayFieldNumber = 6;
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
    public const int HourFieldNumber = 7;
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
    public const int MinuteFieldNumber = 8;
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
      return Equals(other as MessageMetaData);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(MessageMetaData other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ClientID != other.ClientID) return false;
      if (ApiKey != other.ApiKey) return false;
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
      if (Tag.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Tag);
      }
      if (Year != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Year);
      }
      if (Month != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(Month);
      }
      if (Day != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(Day);
      }
      if (Hour != 0) {
        output.WriteRawTag(56);
        output.WriteInt32(Hour);
      }
      if (Minute != 0) {
        output.WriteRawTag(64);
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
      if (Tag.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Tag);
      }
      if (Year != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Year);
      }
      if (Month != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(Month);
      }
      if (Day != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(Day);
      }
      if (Hour != 0) {
        output.WriteRawTag(56);
        output.WriteInt32(Hour);
      }
      if (Minute != 0) {
        output.WriteRawTag(64);
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
    public void MergeFrom(MessageMetaData other) {
      if (other == null) {
        return;
      }
      if (other.ClientID.Length != 0) {
        ClientID = other.ClientID;
      }
      if (other.ApiKey.Length != 0) {
        ApiKey = other.ApiKey;
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
            Tag = input.ReadString();
            break;
          }
          case 32: {
            Year = input.ReadInt32();
            break;
          }
          case 40: {
            Month = input.ReadInt32();
            break;
          }
          case 48: {
            Day = input.ReadInt32();
            break;
          }
          case 56: {
            Hour = input.ReadInt32();
            break;
          }
          case 64: {
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
            Tag = input.ReadString();
            break;
          }
          case 32: {
            Year = input.ReadInt32();
            break;
          }
          case 40: {
            Month = input.ReadInt32();
            break;
          }
          case 48: {
            Day = input.ReadInt32();
            break;
          }
          case 56: {
            Hour = input.ReadInt32();
            break;
          }
          case 64: {
            Minute = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class ValidatorReply : pb::IMessage<ValidatorReply>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ValidatorReply> _parser = new pb::MessageParser<ValidatorReply>(() => new ValidatorReply());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<ValidatorReply> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GrpcMessageNode.ValidatorReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ValidatorReply() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ValidatorReply(ValidatorReply other) : this() {
      replyCode_ = other.replyCode_;
      accountPriority_ = other.accountPriority_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ValidatorReply Clone() {
      return new ValidatorReply(this);
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

    /// <summary>Field number for the "accountPriority" field.</summary>
    public const int AccountPriorityFieldNumber = 2;
    private int accountPriority_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int AccountPriority {
      get { return accountPriority_; }
      set {
        accountPriority_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as ValidatorReply);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(ValidatorReply other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ReplyCode != other.ReplyCode) return false;
      if (AccountPriority != other.AccountPriority) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (ReplyCode.Length != 0) hash ^= ReplyCode.GetHashCode();
      if (AccountPriority != 0) hash ^= AccountPriority.GetHashCode();
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
      if (AccountPriority != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(AccountPriority);
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
      if (AccountPriority != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(AccountPriority);
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
      if (AccountPriority != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(AccountPriority);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(ValidatorReply other) {
      if (other == null) {
        return;
      }
      if (other.ReplyCode.Length != 0) {
        ReplyCode = other.ReplyCode;
      }
      if (other.AccountPriority != 0) {
        AccountPriority = other.AccountPriority;
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
          case 16: {
            AccountPriority = input.ReadInt32();
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
          case 16: {
            AccountPriority = input.ReadInt32();
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