import React from "react";
import { IWorkout } from "../interfaces/IWorkout";
import moment from "moment";
import { Card, ListGroup, Badge } from "react-bootstrap";

interface IProps {
    date: string;
    workouts: Array<IWorkout>;
}

const DailyWorkouts = ({ date, workouts }: IProps) => {
    return (
        <>
            <Card style={{ width: "18rem" }}>
                <Card.Header>{moment(date).format("MMM Do YYYY")}</Card.Header>
                <ListGroup variant="flush">
                    {workouts.map(workout => (
                        <ListGroup.Item key={workout.id}>
                            <Badge variant="primary" className="mx-2">
                                Reps : {workout.reps}
                            </Badge>
                            <Badge variant="warning" className="mx-2">
                                Weight Lifted : {workout.weight}
                            </Badge>
                        </ListGroup.Item>
                    ))}
                </ListGroup>
            </Card>
        </>
    );
};

export default DailyWorkouts;
