import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import DailyWorkouts from "../components/DailyWorkouts";
import { IExercise } from "../interfaces/IExercise";
import { IWorkout, IGroupedWorkout } from "../interfaces/IWorkout";
import _ from "underscore";
import moment from "moment";
import { Container, Row, Col, Button } from "react-bootstrap";
import AddSetModal from "../components/AddSetModal";

const Exercise = () => {
    const { id } = useParams();
    const [showModal, setShowModal] = useState(false);
    const [tickCounter, setTickCounter] = useState(0);
    const [exerciseInfo, setExerciseInfo] = useState<null | IExercise>(null);
    const [workouts, setWorkouts] = useState<null | IGroupedWorkout>(null);
    const [fetchError, setFetchError] = useState(false);

    const groupDataByDate = (data: Array<IWorkout>) => {
        var groupedData: IGroupedWorkout = _.groupBy(data, function(workout) {
            return moment(workout.timeStamp)
                .startOf("date")
                .format();
        });
        return orderByDate(groupedData);
    };

    const orderByDate = (unsortedObj: IGroupedWorkout) => {
        var sortedObj: IGroupedWorkout = {};
        Object.keys(unsortedObj)
            .sort((a, b) => new Date(b).getTime() - new Date(a).getTime())
            .forEach(date => {
                sortedObj[date] = unsortedObj[date];
            });
        return sortedObj;
    };

    const onAddSetClick = () => {
        setShowModal(true);
    };

    const onClose = () => {
        setShowModal(false);
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
                setFetchError(true);
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
                    setFetchError(true);
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
                <Col key={date} md={4} className="my-3">
                    <DailyWorkouts date={date} workouts={workouts[date]} />
                </Col>
            );
        }
        return JSX;
    };

    if (workouts === null && fetchError === true)
        return (
            <>
                <p>Failed to load data</p>
            </>
        );

    if (workouts === null)
        return (
            <>
                <p>Loading...</p>
            </>
        );
    return (
        <>
            <Container>
                <h1>Exercise : {exerciseInfo?.name} 💪</h1>
                <Row className="py-3 justify-content-center">
                    {displayWorkouts()}
                </Row>
                <Row className="mt-5 justify-content-center">
                    <Button variant="light" onClick={onAddSetClick}>
                        Add New Set
                    </Button>
                </Row>
                <AddSetModal
                    show={showModal}
                    onHide={onClose}
                    exercise={exerciseInfo?.name}
                    exerciseid={exerciseInfo?.id}
                />
            </Container>
        </>
    );
};

export default Exercise;
