import React, { useState, useEffect } from "react";
import { Card, Container, Col, Row } from "react-bootstrap";
import { IExercise } from "../interfaces/IExercise";
import { Link } from "react-router-dom";

const Home = () => {
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState(null);
    const [exercises, setExercises] = useState<null | Array<IExercise>>([]);
    useEffect(() => {
        fetch("https://localhost:44384/exercise")
            .then(res => res.json())
            .then(data => {
                setExercises(data);
                setIsLoading(false);
            })
            .catch(error => {
                setIsLoading(false);
                setError(error);
            });
        return () => {
            //CleanUp Here
        };
    }, []);
    return (
        <>
            <Container>
                <h1>Exercises:</h1>
                <br />
                {isLoading === true && <p>Loading...</p>}
                {error && <p>Failed to load data</p>}
                <Row>
                    {exercises?.map(exercise => (
                        <Col md={3} key={exercise.id}>
                            <Link to={`/exercise/${exercise.id}`}>
                                <Card className="my-3">
                                    <Card.Body>{exercise.name}</Card.Body>
                                </Card>
                            </Link>
                        </Col>
                    ))}
                </Row>
            </Container>
        </>
    );
};

export default Home;
