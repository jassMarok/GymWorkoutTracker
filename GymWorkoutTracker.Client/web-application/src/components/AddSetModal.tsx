import React, { useState, useRef } from "react";
import _ from "underscore";
import { Row, Button, Modal, Form } from "react-bootstrap";

const AddSetModal = (props: any) => {
    const refWeightInput = useRef<HTMLInputElement>(null);
    const refRepsInput = useRef<HTMLInputElement>(null);
    const [formValidation, setFormValidation] = useState(false);
    const submitForm = (event: any) => {
        const form = event.currentTarget;
        event.preventDefault();
        event.stopPropagation();
        setFormValidation(true);
        console.log(refWeightInput.current?.value);
        if (
            form.checkValidity() === false ||
            refWeightInput.current == null ||
            refRepsInput.current == null
        ) {
            return;
        }
        fetch("https://localhost:44384/workoutset/", {
            method: "post",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                excerciseId: props?.exerciseid,
                weight: parseFloat(refWeightInput.current?.value),
                reps: parseInt(refRepsInput.current?.value)
            })
        })
            .then(function(response) {
                return response.json();
            })
            .then(function(data) {
                console.log(data);
            });
        props.onHide();
    };
    return (
        <>
            <Modal
                {...props}
                size="lg"
                aria-labelledby="contained-modal-title-vcenter"
                centered
            >
                <Modal.Header closeButton>
                    <Modal.Title id="contained-modal-title-vcenter">
                        Add New {props.exercise} Set
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form
                        onSubmit={submitForm}
                        noValidate
                        validated={formValidation}
                    >
                        <Form.Group controlId="exampleForm.ControlInput1">
                            <Form.Label>Reps</Form.Label>
                            <Form.Control
                                type="number"
                                defaultValue="5"
                                required
                                ref={refRepsInput as React.RefObject<any>}
                            />
                            <Form.Control.Feedback type="invalid">
                                Please enter a reps value.
                            </Form.Control.Feedback>
                        </Form.Group>
                        <Form.Group controlId="exampleForm.ControlInput1">
                            <Form.Label>Weight</Form.Label>
                            <Form.Control
                                type="number"
                                step="0.25"
                                defaultValue="0.25"
                                required
                                ref={refWeightInput as React.RefObject<any>}
                            />
                            <Row className="justify-content-end px-3 py-3">
                                <Button
                                    variant="danger"
                                    className="mr-3"
                                    onClick={props.onHide}
                                >
                                    Close
                                </Button>
                                <Button type="submit">Add Set</Button>
                            </Row>
                        </Form.Group>
                    </Form>
                </Modal.Body>
            </Modal>
        </>
    );
};

export default AddSetModal;
