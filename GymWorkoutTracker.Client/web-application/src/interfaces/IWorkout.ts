export interface IWorkout {
    weight: Number;
    reps: Number;
    timeStamp: string;
    id: string;
}

export interface IGroupedWorkout {
    [date: string]: Array<IWorkout>;
}
