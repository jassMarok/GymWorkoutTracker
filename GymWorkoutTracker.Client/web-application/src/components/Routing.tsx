import React from "react";
import { Switch, Route } from "react-router-dom";
import Exercise from "../pages/Exercise";
import Home from "../pages/Home";

const Routing = () => {
    return (
        <>
            <Switch>
                <Route path="/" component={Home} exact />
                <Route path="/exercise/:id" component={Exercise} />
            </Switch>
        </>
    );
};

export default Routing;
