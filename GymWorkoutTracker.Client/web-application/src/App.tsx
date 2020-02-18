import React, { useState, useEffect } from "react";
import { Card, Container, Col, Row } from "react-bootstrap";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";

interface exerciseData {
    id: string;
    name: string;
    createdAt: string;
}

function App() {
    const [isLoading, setIsLoading] = useState(true);
    const [status, setStatus] = useState("Loading...");
    const [exercises, setExercises] = useState<null | Array<exerciseData>>([]);
    useEffect(() => {
        fetch("https://localhost:44384/exercise")
            .then(res => res.json())
            .then(data => {
                setExercises(data);
                setIsLoading(false);
                setStatus("success");
            })
            .catch(error => {
                setIsLoading(false);
                setStatus("failed");
            });
        return () => {
            //CleanUp Here
        };
    }, []);
    return (
        <div className="App">
            <header className="App-header">Gym Tracker</header>
            <main className="mt-5">
                <Container>
                    <Row>
                        <h1>Exercises:</h1>
                    </Row>
                    <Row>
                        {isLoading || status === "failed" ? (
                            <h2>{status}</h2>
                        ) : (
                            ""
                        )}
                    </Row>
                    <Row>
                        {exercises?.map(exercise => (
                            <Col md={3} key={exercise.id}>
                                <Card className="my-3">
                                    <Card.Body>{exercise.name}</Card.Body>
                                </Card>
                            </Col>
                        ))}
                    </Row>
                </Container>
            </main>
        </div>
    );
}

export default App;
