import { Link } from "react-router-dom";
import { Button, Container, Divider, Header, Image, Segment } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";
import LoginForm from "../users/LoginForm";
import RegisterForm from "../users/RegisterForm";
import FacebookLogin from '@greatsumini/react-facebook-login';

export default observer(function HomePage() {
    const { userStore, modalStore } = useStore();
    return (
        <Segment inverted textAlign="center" vertical className="masthead">
            <Container text>
                <Header as='h1' inverted>
                    <Image size="massive" src='/assets/logo.png' alt='logo' style={{ marginBotoom: 12 }} />
                    Reactivities
                </Header>
                {userStore.isLoggedIn ? (
                    <>
                        <Header as='h2' inverted content="Welcome to Reactivities" />
                        <Button as={Link} to='/activities' size='huge' inverted>
                            Go to Activities!
                        </Button>
                    </>
                ) : (
                    <>
                        <Button onClick={() => modalStore.openModal(<LoginForm/>)} size='huge' inverted>
                            Login!
                        </Button>
                        <Button onClick={() => modalStore.openModal(<RegisterForm/>)} size='huge' inverted>
                            Register
                        </Button>
                        <Divider horizontal inverted>Or</Divider>
                        <FacebookLogin appId="" />
                    </>
                )}
            </Container>
        </Segment>
    )
})