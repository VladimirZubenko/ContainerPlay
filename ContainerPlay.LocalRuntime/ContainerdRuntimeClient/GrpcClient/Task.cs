// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: task.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Containerd.V1.Types {

  /// <summary>Holder for reflection information generated from task.proto</summary>
  public static partial class TaskReflection {

    #region Descriptor
    /// <summary>File descriptor for task.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static TaskReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cgp0YXNrLnByb3RvEhNjb250YWluZXJkLnYxLnR5cGVzGh9nb29nbGUvcHJv",
            "dG9idWYvdGltZXN0YW1wLnByb3RvGhlnb29nbGUvcHJvdG9idWYvYW55LnBy",
            "b3RvIuoBCgdQcm9jZXNzEhQKDGNvbnRhaW5lcl9pZBgBIAEoCRIKCgJpZBgC",
            "IAEoCRILCgNwaWQYAyABKA0SKwoGc3RhdHVzGAQgASgOMhsuY29udGFpbmVy",
            "ZC52MS50eXBlcy5TdGF0dXMSDQoFc3RkaW4YBSABKAkSDgoGc3Rkb3V0GAYg",
            "ASgJEg4KBnN0ZGVychgHIAEoCRIQCgh0ZXJtaW5hbBgIIAEoCBITCgtleGl0",
            "X3N0YXR1cxgJIAEoDRItCglleGl0ZWRfYXQYCiABKAsyGi5nb29nbGUucHJv",
            "dG9idWYuVGltZXN0YW1wIj4KC1Byb2Nlc3NJbmZvEgsKA3BpZBgBIAEoDRIi",
            "CgRpbmZvGAIgASgLMhQuZ29vZ2xlLnByb3RvYnVmLkFueSpVCgZTdGF0dXMS",
            "CwoHVU5LTk9XThAAEgsKB0NSRUFURUQQARILCgdSVU5OSU5HEAISCwoHU1RP",
            "UFBFRBADEgoKBlBBVVNFRBAEEgsKB1BBVVNJTkcQBUIxWi9naXRodWIuY29t",
            "L2NvbnRhaW5lcmQvY29udGFpbmVyZC9hcGkvdHlwZXMvdGFza2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.AnyReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Containerd.V1.Types.Status), }, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Containerd.V1.Types.Process), global::Containerd.V1.Types.Process.Parser, new[]{ "ContainerId", "Id", "Pid", "Status", "Stdin", "Stdout", "Stderr", "Terminal", "ExitStatus", "ExitedAt" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Containerd.V1.Types.ProcessInfo), global::Containerd.V1.Types.ProcessInfo.Parser, new[]{ "Pid", "Info" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum Status {
    [pbr::OriginalName("UNKNOWN")] Unknown = 0,
    [pbr::OriginalName("CREATED")] Created = 1,
    [pbr::OriginalName("RUNNING")] Running = 2,
    [pbr::OriginalName("STOPPED")] Stopped = 3,
    [pbr::OriginalName("PAUSED")] Paused = 4,
    [pbr::OriginalName("PAUSING")] Pausing = 5,
  }

  #endregion

  #region Messages
  public sealed partial class Process : pb::IMessage<Process>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Process> _parser = new pb::MessageParser<Process>(() => new Process());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<Process> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Containerd.V1.Types.TaskReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Process() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Process(Process other) : this() {
      containerId_ = other.containerId_;
      id_ = other.id_;
      pid_ = other.pid_;
      status_ = other.status_;
      stdin_ = other.stdin_;
      stdout_ = other.stdout_;
      stderr_ = other.stderr_;
      terminal_ = other.terminal_;
      exitStatus_ = other.exitStatus_;
      exitedAt_ = other.exitedAt_ != null ? other.exitedAt_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Process Clone() {
      return new Process(this);
    }

    /// <summary>Field number for the "container_id" field.</summary>
    public const int ContainerIdFieldNumber = 1;
    private string containerId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string ContainerId {
      get { return containerId_; }
      set {
        containerId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 2;
    private string id_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Id {
      get { return id_; }
      set {
        id_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "pid" field.</summary>
    public const int PidFieldNumber = 3;
    private uint pid_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint Pid {
      get { return pid_; }
      set {
        pid_ = value;
      }
    }

    /// <summary>Field number for the "status" field.</summary>
    public const int StatusFieldNumber = 4;
    private global::Containerd.V1.Types.Status status_ = global::Containerd.V1.Types.Status.Unknown;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Containerd.V1.Types.Status Status {
      get { return status_; }
      set {
        status_ = value;
      }
    }

    /// <summary>Field number for the "stdin" field.</summary>
    public const int StdinFieldNumber = 5;
    private string stdin_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Stdin {
      get { return stdin_; }
      set {
        stdin_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "stdout" field.</summary>
    public const int StdoutFieldNumber = 6;
    private string stdout_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Stdout {
      get { return stdout_; }
      set {
        stdout_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "stderr" field.</summary>
    public const int StderrFieldNumber = 7;
    private string stderr_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Stderr {
      get { return stderr_; }
      set {
        stderr_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "terminal" field.</summary>
    public const int TerminalFieldNumber = 8;
    private bool terminal_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Terminal {
      get { return terminal_; }
      set {
        terminal_ = value;
      }
    }

    /// <summary>Field number for the "exit_status" field.</summary>
    public const int ExitStatusFieldNumber = 9;
    private uint exitStatus_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint ExitStatus {
      get { return exitStatus_; }
      set {
        exitStatus_ = value;
      }
    }

    /// <summary>Field number for the "exited_at" field.</summary>
    public const int ExitedAtFieldNumber = 10;
    private global::Google.Protobuf.WellKnownTypes.Timestamp exitedAt_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Protobuf.WellKnownTypes.Timestamp ExitedAt {
      get { return exitedAt_; }
      set {
        exitedAt_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as Process);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(Process other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ContainerId != other.ContainerId) return false;
      if (Id != other.Id) return false;
      if (Pid != other.Pid) return false;
      if (Status != other.Status) return false;
      if (Stdin != other.Stdin) return false;
      if (Stdout != other.Stdout) return false;
      if (Stderr != other.Stderr) return false;
      if (Terminal != other.Terminal) return false;
      if (ExitStatus != other.ExitStatus) return false;
      if (!object.Equals(ExitedAt, other.ExitedAt)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (ContainerId.Length != 0) hash ^= ContainerId.GetHashCode();
      if (Id.Length != 0) hash ^= Id.GetHashCode();
      if (Pid != 0) hash ^= Pid.GetHashCode();
      if (Status != global::Containerd.V1.Types.Status.Unknown) hash ^= Status.GetHashCode();
      if (Stdin.Length != 0) hash ^= Stdin.GetHashCode();
      if (Stdout.Length != 0) hash ^= Stdout.GetHashCode();
      if (Stderr.Length != 0) hash ^= Stderr.GetHashCode();
      if (Terminal != false) hash ^= Terminal.GetHashCode();
      if (ExitStatus != 0) hash ^= ExitStatus.GetHashCode();
      if (exitedAt_ != null) hash ^= ExitedAt.GetHashCode();
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
      if (ContainerId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ContainerId);
      }
      if (Id.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Id);
      }
      if (Pid != 0) {
        output.WriteRawTag(24);
        output.WriteUInt32(Pid);
      }
      if (Status != global::Containerd.V1.Types.Status.Unknown) {
        output.WriteRawTag(32);
        output.WriteEnum((int) Status);
      }
      if (Stdin.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Stdin);
      }
      if (Stdout.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(Stdout);
      }
      if (Stderr.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(Stderr);
      }
      if (Terminal != false) {
        output.WriteRawTag(64);
        output.WriteBool(Terminal);
      }
      if (ExitStatus != 0) {
        output.WriteRawTag(72);
        output.WriteUInt32(ExitStatus);
      }
      if (exitedAt_ != null) {
        output.WriteRawTag(82);
        output.WriteMessage(ExitedAt);
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
      if (ContainerId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ContainerId);
      }
      if (Id.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Id);
      }
      if (Pid != 0) {
        output.WriteRawTag(24);
        output.WriteUInt32(Pid);
      }
      if (Status != global::Containerd.V1.Types.Status.Unknown) {
        output.WriteRawTag(32);
        output.WriteEnum((int) Status);
      }
      if (Stdin.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Stdin);
      }
      if (Stdout.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(Stdout);
      }
      if (Stderr.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(Stderr);
      }
      if (Terminal != false) {
        output.WriteRawTag(64);
        output.WriteBool(Terminal);
      }
      if (ExitStatus != 0) {
        output.WriteRawTag(72);
        output.WriteUInt32(ExitStatus);
      }
      if (exitedAt_ != null) {
        output.WriteRawTag(82);
        output.WriteMessage(ExitedAt);
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
      if (ContainerId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ContainerId);
      }
      if (Id.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Id);
      }
      if (Pid != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Pid);
      }
      if (Status != global::Containerd.V1.Types.Status.Unknown) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Status);
      }
      if (Stdin.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Stdin);
      }
      if (Stdout.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Stdout);
      }
      if (Stderr.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Stderr);
      }
      if (Terminal != false) {
        size += 1 + 1;
      }
      if (ExitStatus != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(ExitStatus);
      }
      if (exitedAt_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ExitedAt);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(Process other) {
      if (other == null) {
        return;
      }
      if (other.ContainerId.Length != 0) {
        ContainerId = other.ContainerId;
      }
      if (other.Id.Length != 0) {
        Id = other.Id;
      }
      if (other.Pid != 0) {
        Pid = other.Pid;
      }
      if (other.Status != global::Containerd.V1.Types.Status.Unknown) {
        Status = other.Status;
      }
      if (other.Stdin.Length != 0) {
        Stdin = other.Stdin;
      }
      if (other.Stdout.Length != 0) {
        Stdout = other.Stdout;
      }
      if (other.Stderr.Length != 0) {
        Stderr = other.Stderr;
      }
      if (other.Terminal != false) {
        Terminal = other.Terminal;
      }
      if (other.ExitStatus != 0) {
        ExitStatus = other.ExitStatus;
      }
      if (other.exitedAt_ != null) {
        if (exitedAt_ == null) {
          ExitedAt = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        ExitedAt.MergeFrom(other.ExitedAt);
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
            ContainerId = input.ReadString();
            break;
          }
          case 18: {
            Id = input.ReadString();
            break;
          }
          case 24: {
            Pid = input.ReadUInt32();
            break;
          }
          case 32: {
            Status = (global::Containerd.V1.Types.Status) input.ReadEnum();
            break;
          }
          case 42: {
            Stdin = input.ReadString();
            break;
          }
          case 50: {
            Stdout = input.ReadString();
            break;
          }
          case 58: {
            Stderr = input.ReadString();
            break;
          }
          case 64: {
            Terminal = input.ReadBool();
            break;
          }
          case 72: {
            ExitStatus = input.ReadUInt32();
            break;
          }
          case 82: {
            if (exitedAt_ == null) {
              ExitedAt = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(ExitedAt);
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
            ContainerId = input.ReadString();
            break;
          }
          case 18: {
            Id = input.ReadString();
            break;
          }
          case 24: {
            Pid = input.ReadUInt32();
            break;
          }
          case 32: {
            Status = (global::Containerd.V1.Types.Status) input.ReadEnum();
            break;
          }
          case 42: {
            Stdin = input.ReadString();
            break;
          }
          case 50: {
            Stdout = input.ReadString();
            break;
          }
          case 58: {
            Stderr = input.ReadString();
            break;
          }
          case 64: {
            Terminal = input.ReadBool();
            break;
          }
          case 72: {
            ExitStatus = input.ReadUInt32();
            break;
          }
          case 82: {
            if (exitedAt_ == null) {
              ExitedAt = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(ExitedAt);
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class ProcessInfo : pb::IMessage<ProcessInfo>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ProcessInfo> _parser = new pb::MessageParser<ProcessInfo>(() => new ProcessInfo());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<ProcessInfo> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Containerd.V1.Types.TaskReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProcessInfo() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProcessInfo(ProcessInfo other) : this() {
      pid_ = other.pid_;
      info_ = other.info_ != null ? other.info_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProcessInfo Clone() {
      return new ProcessInfo(this);
    }

    /// <summary>Field number for the "pid" field.</summary>
    public const int PidFieldNumber = 1;
    private uint pid_;
    /// <summary>
    /// PID is the process ID.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint Pid {
      get { return pid_; }
      set {
        pid_ = value;
      }
    }

    /// <summary>Field number for the "info" field.</summary>
    public const int InfoFieldNumber = 2;
    private global::Google.Protobuf.WellKnownTypes.Any info_;
    /// <summary>
    /// Info contains additional process information.
    ///
    /// Info varies by platform.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Protobuf.WellKnownTypes.Any Info {
      get { return info_; }
      set {
        info_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as ProcessInfo);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(ProcessInfo other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Pid != other.Pid) return false;
      if (!object.Equals(Info, other.Info)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Pid != 0) hash ^= Pid.GetHashCode();
      if (info_ != null) hash ^= Info.GetHashCode();
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
      if (Pid != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(Pid);
      }
      if (info_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Info);
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
      if (Pid != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(Pid);
      }
      if (info_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Info);
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
      if (Pid != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Pid);
      }
      if (info_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Info);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(ProcessInfo other) {
      if (other == null) {
        return;
      }
      if (other.Pid != 0) {
        Pid = other.Pid;
      }
      if (other.info_ != null) {
        if (info_ == null) {
          Info = new global::Google.Protobuf.WellKnownTypes.Any();
        }
        Info.MergeFrom(other.Info);
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
          case 8: {
            Pid = input.ReadUInt32();
            break;
          }
          case 18: {
            if (info_ == null) {
              Info = new global::Google.Protobuf.WellKnownTypes.Any();
            }
            input.ReadMessage(Info);
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
          case 8: {
            Pid = input.ReadUInt32();
            break;
          }
          case 18: {
            if (info_ == null) {
              Info = new global::Google.Protobuf.WellKnownTypes.Any();
            }
            input.ReadMessage(Info);
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
