import grpc from "@grpc/grpc-js";
import protoLoader from "@grpc/proto-loader";
import type { ProtoGrpcType } from "./proto/courses";
import { promisify } from "util";

const ProtoPath = "../Courses/Protos/courses.proto";

const packageDefinition = protoLoader.loadSync(ProtoPath, {
	keepCase: true,
	defaults: true,
	oneofs: true,
});

const protoDescriptor = grpc.loadPackageDefinition(packageDefinition) as unknown as ProtoGrpcType;

export const CoursesApi = protoDescriptor.courses.CoursesApi;

export class CoursesApiClient {
	public readonly client;

	constructor() {
		this.client = new CoursesApi("127.0.0.1:5227", grpc.credentials.createInsecure());
	}

	public rpc(name: keyof typeof this.client) {
		return promisify(this.client[name]).bind(this.client);
	}
}
