import type * as grpc from '@grpc/grpc-js';
import type { MessageTypeDefinition } from '@grpc/proto-loader';

import type { GreeterClient as _greet_GreeterClient, GreeterDefinition as _greet_GreeterDefinition } from './greet/Greeter';
import type { HelloReply as _greet_HelloReply, HelloReply__Output as _greet_HelloReply__Output } from './greet/HelloReply';
import type { HelloRequest as _greet_HelloRequest, HelloRequest__Output as _greet_HelloRequest__Output } from './greet/HelloRequest';

type SubtypeConstructor<Constructor extends new (...args: any) => any, Subtype> = {
  new(...args: ConstructorParameters<Constructor>): Subtype;
};

export interface ProtoGrpcType {
  greet: {
    Greeter: SubtypeConstructor<typeof grpc.Client, _greet_GreeterClient> & { service: _greet_GreeterDefinition }
    HelloReply: MessageTypeDefinition<_greet_HelloReply, _greet_HelloReply__Output>
    HelloRequest: MessageTypeDefinition<_greet_HelloRequest, _greet_HelloRequest__Output>
  }
}

