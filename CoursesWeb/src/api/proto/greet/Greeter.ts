// Original file: ../Courses/Protos/greet.proto

import type * as grpc from '@grpc/grpc-js'
import type { MethodDefinition } from '@grpc/proto-loader'
import type { HelloReply as _greet_HelloReply, HelloReply__Output as _greet_HelloReply__Output } from '../greet/HelloReply';
import type { HelloRequest as _greet_HelloRequest, HelloRequest__Output as _greet_HelloRequest__Output } from '../greet/HelloRequest';

export interface GreeterClient extends grpc.Client {
  SayHello(argument: _greet_HelloRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_greet_HelloReply__Output>): grpc.ClientUnaryCall;
  SayHello(argument: _greet_HelloRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_greet_HelloReply__Output>): grpc.ClientUnaryCall;
  SayHello(argument: _greet_HelloRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_greet_HelloReply__Output>): grpc.ClientUnaryCall;
  SayHello(argument: _greet_HelloRequest, callback: grpc.requestCallback<_greet_HelloReply__Output>): grpc.ClientUnaryCall;
  sayHello(argument: _greet_HelloRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_greet_HelloReply__Output>): grpc.ClientUnaryCall;
  sayHello(argument: _greet_HelloRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_greet_HelloReply__Output>): grpc.ClientUnaryCall;
  sayHello(argument: _greet_HelloRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_greet_HelloReply__Output>): grpc.ClientUnaryCall;
  sayHello(argument: _greet_HelloRequest, callback: grpc.requestCallback<_greet_HelloReply__Output>): grpc.ClientUnaryCall;
  
}

export interface GreeterHandlers extends grpc.UntypedServiceImplementation {
  SayHello: grpc.handleUnaryCall<_greet_HelloRequest__Output, _greet_HelloReply>;
  
}

export interface GreeterDefinition extends grpc.ServiceDefinition {
  SayHello: MethodDefinition<_greet_HelloRequest, _greet_HelloReply, _greet_HelloRequest__Output, _greet_HelloReply__Output>
}
