import grpc from "@grpc/grpc-js";
import protoLoader from "@grpc/proto-loader";
import { promisify } from "util";

import type { ProtoGrpcType } from "./proto/courses";

const BackendUrl = process.env.BACKEND_URL || "127.0.0.1:5227";
// TODO: Override this in production
const ProtoPath = "../Courses/Protos/courses.proto";

const packageDefinition = protoLoader.loadSync(ProtoPath, {
	keepCase: false,
	defaults: true,
	oneofs: true,
});

const protoDescriptor = grpc.loadPackageDefinition(packageDefinition) as unknown as ProtoGrpcType;

export const CoursesApi = protoDescriptor.courses.CoursesApi;

export class CoursesApiClient {
	public readonly client;

	constructor() {
		this.client = new CoursesApi(BackendUrl, grpc.credentials.createInsecure());
	}

	public rpc(name: keyof typeof this.client) {
		return promisify(this.client[name]).bind(this.client);
	}
}
