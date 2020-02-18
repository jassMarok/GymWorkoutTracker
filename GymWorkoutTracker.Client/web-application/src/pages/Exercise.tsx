import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { IExercise } from "../interfaces/IExercise";
import { IWorkout, IGroupedWorkout } from "../interfaces/IWorkout";
import _ from "underscore";
import moment from "moment";

const Exercise = () => {
    const { id } = useParams();
    const [exerciseInfo, setExerciseInfo] = useState<null | IExercise>(null);
    const [workouts, setWorkouts] = useState<null | IGroupedWorkout>(null);

    const groupDataByDate = (data: Array<IWorkout>) => {
        var groupedData: IGroupedWorkout = _.groupBy(data, function(workout) {
            return moment(workout.timeStamp)
                .startOf("date")
                .format();
        });
        return groupedData;
    };

    const displayGroupedWorkouts = (data: any) => {
        let dates = Object.keys(data);
        let values: any = Object.values(data);
        let table = [];
        let parent = [];
        for (let index = 0; index < dates.length; index++) {
            const currentDate = dates[index];
            let children = [];
            for (let j = 0; j < values[index].length; j++) {
                const workout = values[index][j];
                children.push(
                    <li key={index + j.toString()}>
                        Reps: {workout.reps} | Weight : {workout.weight} | Time
                        : {workout.timeStamp}
                    </li>
                );
            }
            table.push(
                <ul key={index.toString() + currentDate.toString()}>
                    <li key={currentDate}>{currentDate}</li>
                    {children}
                </ul>
            );
        }
        parent.push(<div key={"jatt"}>{table}</div>);
        return parent;
    };

    useEffect(() => {
        /**
         * Get Exercise Info
         */
        fetch(`https://localhost:44384/exercise/${id}`)
            .then(res => res.json())
            .then(data => {
                setExerciseInfo(data);
            })
            .catch(error => {
                console.log(error);
            });
        /**
         * Get Workouts
         */
        fetch(`https://localhost:44384/workoutset/exercise/${id}`)
            .then(res => res.json())
            .then(data => {
                setWorkouts(groupDataByDate(data));
            })
            .catch(error => {
                console.log(error);
            });
        return () => {
            //Clean Up
        };
    }, []);
    if (workouts === null) return <></>;
    return (
        <>
            <h1>Exercise : {exerciseInfo?.name} 💪</h1>
            {displayGroupedWorkouts(workouts)}
        </>
    );
};

export default Exercise;
