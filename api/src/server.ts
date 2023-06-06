import fastify from 'fastify'
import jwt from '@fastify/jwt'
import cors from '@fastify/cors'

import { userRoutes } from './routes/user-routes'

const app = fastify()

app.register(cors, {
    origin: true,
})

app.register(jwt, {
    secret: '123'
})

app.register(userRoutes)

app.listen({ port: 3333 }).then(() => console.log('Server is running on port 3333'))