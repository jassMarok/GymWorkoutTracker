export interface IWorkout {
    weight: Number;
    reps: Number;
    timeStamp: string;
}

export interface IGroupedWorkout {
    [date: string]: Array<IWorkout>;
}
