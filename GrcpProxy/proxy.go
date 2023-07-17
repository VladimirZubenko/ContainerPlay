package main

import (
	"context"
	"log"
	"net"

	"github.com/containerd/containerd/api/services/containers/v1"
	"google.golang.org/grpc"
	"github.com/gogo/protobuf/types"
	"github.com/containerd/containerd/namespaces"
	"github.com/containerd/containerd/api/services/tasks/v1"
)

type containersProxyService struct {
	client containers.ContainersClient
}

type tasksProxyService struct {
	client tasks.TasksClient
}

func (s *containersProxyService) List(ctx context.Context, req *containers.ListContainersRequest) (*containers.ListContainersResponse, error) {
	ctx = namespaces.WithNamespace(ctx, "default")
	return s.client.List(ctx, req)
}

func (s *containersProxyService) Create(ctx context.Context, req *containers.CreateContainerRequest) (*containers.CreateContainerResponse, error) {
	ctx = namespaces.WithNamespace(ctx, "default")
	return s.client.Create(ctx, req)
}

func (s *containersProxyService) Delete(ctx context.Context, req *containers.DeleteContainerRequest) (*types.Empty, error) {
	ctx = namespaces.WithNamespace(ctx, "default")
	return s.client.Delete(ctx, req)
}

func (s *tasksProxyService) Create(ctx context.Context, req *tasks.CreateTaskRequest) (*tasks.CreateTaskResponse, error) {
    ctx = namespaces.WithNamespace(ctx, "default")
    return s.client.Create(ctx, req)
}

func (s *tasksProxyService) Delete(ctx context.Context, req *tasks.DeleteTaskRequest) (*tasks.DeleteResponse, error) {
    ctx = namespaces.WithNamespace(ctx, "default")
    return s.client.Delete(ctx, req)
}

func (s *tasksProxyService) Start(ctx context.Context, req *tasks.StartRequest) (*tasks.StartResponse, error) {
    ctx = namespaces.WithNamespace(ctx, "default")
    return s.client.Start(ctx, req)
}

func (s *tasksProxyService) Kill(ctx context.Context, req *tasks.KillRequest) (*types.Empty, error) {
    ctx = namespaces.WithNamespace(ctx, "default")
    return s.client.Kill(ctx, req)
}

func (s *containersProxyService) Get(ctx context.Context, req *containers.GetContainerRequest) (*containers.GetContainerResponse, error) {
	return nil, nil
}

func (s *containersProxyService) Update(ctx context.Context, req *containers.UpdateContainerRequest) (*containers.UpdateContainerResponse, error) {
	return nil, nil
}

func (s *containersProxyService) ListStream(*containers.ListContainersRequest, containers.Containers_ListStreamServer) error {
	return nil
}

func (s *tasksProxyService) Checkpoint(ctx context.Context, req *tasks.CheckpointTaskRequest) (*tasks.CheckpointTaskResponse, error) {
	return nil, nil
}

func (s *tasksProxyService) CloseIO(ctx context.Context, req *tasks.CloseIORequest) (*types.Empty, error) {
    return nil, nil
}

func (s *tasksProxyService) DeleteProcess(ctx context.Context, req *tasks.DeleteProcessRequest) (*tasks.DeleteResponse, error) {
	return nil, nil
}

func (s *tasksProxyService) Exec(ctx context.Context, req *tasks.ExecProcessRequest) (*types.Empty, error) {
    return nil, nil
}

func (s *tasksProxyService) Get(ctx context.Context, req *tasks.GetRequest) (*tasks.GetResponse, error) {
    return nil, nil
}

func (s *tasksProxyService) List(ctx context.Context, req *tasks.ListTasksRequest) (*tasks.ListTasksResponse, error) {
    return nil, nil
}

func (s *tasksProxyService) ListPids(ctx context.Context, req *tasks.ListPidsRequest) (*tasks.ListPidsResponse, error) {
    return nil, nil
}

func (s *tasksProxyService) Metrics(ctx context.Context, req *tasks.MetricsRequest) (*tasks.MetricsResponse, error) {
    return nil, nil
}

func (s *tasksProxyService) Pause(ctx context.Context, req *tasks.PauseTaskRequest) (*types.Empty, error) {
    return nil, nil
}

func (s *tasksProxyService) ResizePty(ctx context.Context, req *tasks.ResizePtyRequest) (*types.Empty, error) {
    return nil, nil
}

func (s *tasksProxyService) Resume(ctx context.Context, req *tasks.ResumeTaskRequest) (*types.Empty, error) {
    return nil, nil
}

func (s *tasksProxyService) Update(ctx context.Context, req *tasks.UpdateTaskRequest) (*types.Empty, error) {
    return nil, nil
}

func (s *tasksProxyService) Wait(ctx context.Context, req *tasks.WaitRequest) (*tasks.WaitResponse, error) {
    return nil, nil
}

func main() {
	// Create a client connection to the containerd Unix Domain Socket
	cc, err := grpc.Dial("unix:///run/containerd/containerd.sock", grpc.WithInsecure())
	if err != nil {
		log.Fatalf("failed to dial containerd: %v", err)
	}

	// Create the proxy services
	cps := &containersProxyService{
		client: containers.NewContainersClient(cc),
	}
	tps := &tasksProxyService{
		client: tasks.NewTasksClient(cc),
	}

	// Create a new gRPC server
	server := grpc.NewServer()

	// Register the proxy services with the server
	containers.RegisterContainersServer(server, cps)
	tasks.RegisterTasksServer(server, tps)

	// Create a TCP listener on port 5001
	lis, err := net.Listen("tcp", ":5001")
	if err != nil {
		log.Fatalf("failed to listen: %v", err)
	}

	// Start the gRPC server
	if err := server.Serve(lis); err != nil {
		log.Fatalf("failed to serve: %v", err)
	}
}
