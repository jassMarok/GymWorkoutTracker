import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import DailyWorkouts from "../components/DailyWorkouts";
import { IExercise } from "../interfaces/IExercise";
import { IWorkout, IGroupedWorkout } from "../interfaces/IWorkout";
import _ from "underscore";
import moment from "moment";
import { Container, Row, Col } from "react-bootstrap";

const Exercise = () => {
    const { id } = useParams();
    const [tickCounter, setTickCounter] = useState(0);
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

    useEffect(() => {
        /**
         * Setup Timer
         */
        const timer = setInterval(() => {
            setTickCounter(prevState => (prevState < 5 ? prevState + 1 : 0));
        }, 1000);

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

        return () => {
            clearInterval(timer);
        };
    }, []);

    useEffect(() => {
        if (tickCounter === 0) {
            /**
             * Get Workouts
             */
            fetch(`https://localhost:44384/workoutset/exercise/${id}`)
                .then(res => res.json())
                .then(data => {
                    setWorkouts(groupDataByDate(data));
                    console.log("New Data Fetched");
                })
                .catch(error => {
                    console.log(error);
                });
        }
        return () => {
            //Clean Up
        };
    }, [tickCounter]);

    const displayWorkouts = () => {
        const JSX = [];
        for (const date in workouts) {
            JSX.push(
                <Col key={date} md={4}>
                    <DailyWorkouts date={date} workouts={workouts[date]} />
                </Col>
            );
        }
        return JSX;
    };

    if (workouts === null) return <></>;
    return (
        <>
            <Container>
                <h1>Exercise : {exerciseInfo?.name} 💪</h1>
                <Row className="py-3">{displayWorkouts()}</Row>
            </Container>
        </>
    );
};

export default Exercise;
